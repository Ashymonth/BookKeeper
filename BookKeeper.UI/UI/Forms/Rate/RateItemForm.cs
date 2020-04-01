using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Rate;
using BookKeeper.UI.Helpers;
using BookKeeper.UI.Models.Rate;
using MetroFramework.Forms;

namespace BookKeeper.UI.UI.Forms.Rate
{
    public partial class RateItemForm : MetroForm
    {
        private readonly IContainer _container;

        public RateItemForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void Initialize()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IStreetService>();

                var result = service.GetItems().Where(x => x.IsDeleted == false).ToList();
                cmbStreet.DataSource = result;
                cmbStreet.DisplayMember = "Street";
                cmbStreet.ValueMember = "Id";
            }
        }

        private void RateItemForm_Load(object sender, EventArgs e)
        {
            Initialize();
            if (RateModel == null)
                return;

            txtHouse.Text = RateModel.House;
            txtBuilding.Text = RateModel.Building;
            txtPrice.Text = RateModel.Price;
            dateFrom.Value = RateModel.Start;
            dateTo.Value = RateModel.End;
        }

        public RateModel RateModel { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (dateFrom.Value == dateTo.Value)
            {
                MessageBoxHelper.ShowWarningMessage("Даты не могу совпадать", this);
                return;
            }


            if (dateFrom.Value.Month == dateTo.Value.Month && dateFrom.Value.Year == dateTo.Value.Year)
            {
                MessageBoxHelper.ShowWarningMessage("Месяца должны быть разными", this);
                return;
            }

            if (dateFrom.Value > dateTo.Value)
            {
                MessageBoxHelper.ShowWarningMessage("Дата начала не может быть больше", this);
                return;
            }

            if (cmbStreet.SelectedValue is int streetId)
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var locationService = scope.Resolve<ILocationService>();

                    var location = locationService.GetHouse(streetId, txtHouse.Text, txtBuilding.Text);
                    if (location == null)
                    {
                        MessageBoxHelper.ShowWarningMessage("Такого адреса нет в базе", this);
                        return;
                    }

                    var service = scope.Resolve<IRateService>();
                    var currentRate = service.GetItems(x => x.IsArchive == false && x.IsDeleted == false)
                        .ToList()
                        .Where(x => x.AssignedLocations.LastOrDefault(z => z.LocationRefId == location.Id && z.IsDeleted == false) != null)
                        .ToList();
                    foreach (var rateEntity in currentRate)
                    {
                        if(rateEntity.IsDefault || rateEntity.IsArchive)
                            continue;

                        var rate = service.GetItemById(rateEntity.Id);
                        if (rate == null) 
                            continue;

                        rate.EndDate = DateTime.Now;
                        rate.IsArchive = true;
                        service.Update(rate);
                        break;
                    }

                    var document = service.AddRate(location.Id, txtDescription.Text, Convert.ToDecimal(txtPrice.Text), dateFrom.Value, dateTo.Value);

                    if (cmbStreet.SelectedItem is StreetEntity result)
                    {
                        RateModel = new RateModel
                        {
                            Street = result.StreetName,
                            House = txtHouse.Text,
                            Building = txtBuilding.Text,
                            Price = txtPrice.Text,
                            Description = txtDescription.Text,
                            RateDocument = document
                        };
                    }
                }
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBoxHelper.ShowWarningMessage("Ошибка", this);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
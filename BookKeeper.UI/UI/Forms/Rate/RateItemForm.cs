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

            cmbHouses.Text = RateModel.House;
            cmbBuildings.Text = RateModel.Building;
            txtPrice.Text = RateModel.Price;
        }

        public RateModel RateModel { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (cmbStreet.SelectedValue is int streetId)
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var locationService = scope.Resolve<ILocationService>();

                    var location = locationService.GetHouse(streetId, cmbHouses.Text, cmbBuildings.Text);
                    if (location == null)
                    {
                        MessageBoxHelper.ShowWarningMessage("Такого адреса нет в базе", this);
                        return;
                    }

                    var service = scope.Resolve<IRateService>();

                    var document = service.AddRate(location, txtDescription.Text, Convert.ToDecimal(txtPrice.Text));

                    if (cmbStreet.SelectedItem is StreetEntity result)
                    {
                        RateModel = new RateModel
                        {
                            Street = result.StreetName,
                            House = cmbHouses.Text,
                            Building = cmbBuildings.Text,
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
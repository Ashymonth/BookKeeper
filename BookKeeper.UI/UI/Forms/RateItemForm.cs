using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using MetroFramework.Forms;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Rate;

namespace BookKeeper.UI.UI.Forms
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

        }

        public RateModel RateModel;
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();

                var location = locationService.GetItem(x => string.Equals(x.HouseNumber, txtHouse.Text, StringComparison.CurrentCultureIgnoreCase) &&
                                                            string.Equals(x.BuildingCorpus, txtBuilding.Text, StringComparison.CurrentCultureIgnoreCase) &&
                                                            x.StreetId == (int)cmbStreet.SelectedValue);
                if (location == null)
                {
                    MessageBox.Show("Такого адреса нет в базе");
                    return;
                }

                var service = scope.Resolve<IRateDocumentService>();

                int streetId;
                if (cmbStreet.SelectedValue is int id)
                {
                    streetId = id;
                }
                else
                {
                    MessageBox.Show("Укажите улицу");
                    return;
                }

                var document = service.AddRateDocument(streetId, location.Id, txtDescription.Text,
                    Convert.ToDecimal(txtPrice.Text, new CultureInfo("en-US")));

                RateModel = new RateModel
                {
                    Street = cmbStreet.SelectedText,
                    House = txtHouse.Text,
                    Building = txtBuilding.Text,
                    Price = txtPrice.Text,
                    Description = txtDescription.Text,
                    RateId = document.Id
                };
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

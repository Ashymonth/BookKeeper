using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using MetroFramework.Forms;
using System;
using System.Globalization;
using System.Linq;
using BookKeeper.Data.Data.Entities.Rates;
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
                var service = scope.Resolve<IAddressService>();

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

            RateModel = new RateModel
            {
                StreetId = (int)cmbStreet.SelectedValue,
                House = txtHouse.Text,
                Building = txtBuilding.Text,
                Description = txtDescription.Text,
                Price = Convert.ToDecimal(txtPrice.Text)
            };
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IRateDocumentService>();
                var document = service.AddRateDocument((int) cmbStreet.SelectedValue,txtDescription.Text,Convert.ToDecimal(txtPrice.Text,new CultureInfo("en-US")));
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

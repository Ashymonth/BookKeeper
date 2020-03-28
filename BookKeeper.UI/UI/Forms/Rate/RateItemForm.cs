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
        }

        public RateModel RateModel { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();

                var location = locationService.GetLocation((int)cmbStreet.SelectedValue,txtHouse.Text,txtBuilding.Text);
                if (location == null)
                {
                    MessageBox.Show("Такого адреса нет в базе");
                    return;
                }

                var service = scope.Resolve<IRateDocumentService>();

                if (dateStart.Value.Month == dateEnd.Value.Month)
                {
                    MessageBox.Show("Месяца должны быть разными");
                    return;
                }

                var document = service.AddRateDocument(location.Id, txtDescription.Text,
                    Convert.ToDecimal(txtPrice.Text, new CultureInfo("en-US")),dateStart.Value,dateEnd.Value);


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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

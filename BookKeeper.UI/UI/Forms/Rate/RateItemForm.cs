using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Rate;
using BookKeeper.UI.Helpers;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace BookKeeper.UI.UI.Forms.Rate
{
    public partial class RateItemForm : MetroForm
    {
        private readonly IContainer _container;
        private readonly DataSourceHelper _dataSourceHelper;

        public RateItemForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
            _dataSourceHelper = new DataSourceHelper();
        }

        private void Initialize()
        {
            _dataSourceHelper.LoadAddresses(cmbStreet);
        }

        private void RateItemForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBoxHelper.ShowWarningMessage("Укажите цену", this);
                return;
            }

            if (dateFrom.Value.Date == dateTo.Value.Date)
            {
                MessageBoxHelper.ShowWarningMessage("Даты должны различаться", this);
                return;
            }

            decimal price;
            try
            {
                price = Convert.ToDecimal(txtPrice.Text);
            }
            catch (FormatException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            catch (OverflowException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

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

                    service.AddRate(location, txtDescription.Text, price, dateFrom.Value.Date, dateTo.Value.Date);

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

        private void cmbStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBuildings.DataSource = null;
            cmbHouses.DataSource = null;
            _dataSourceHelper.StreetIndexChanged(cmbStreet, cmbHouses, x => x.HouseNumber);

        }

        private void cmbHouses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _dataSourceHelper.HouseIndexChanged(cmbStreet, cmbHouses, cmbBuildings, x => x.BuildingCorpus);
        }
    }
}
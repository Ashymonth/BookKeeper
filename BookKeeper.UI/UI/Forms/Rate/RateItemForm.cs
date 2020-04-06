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

                    var result = service.AddRate(location, txtDescription.Text, Convert.ToDecimal(txtPrice.Text));

//#if DEBUG
//                    if (result == null)
//                    {
//                        MessageBoxHelper.ShowWarningMessage("Действующий тариф уже создан. Добавление 2 тарифов на 1 адрес в 1 день невозможно. Удалите действующий тариф и попробуйте снова",this);
//                        return;
//                    }
//#endif

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
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.UI.Helpers;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace BookKeeper.UI.UI.Forms.Houses
{
    public partial class DeleteHouseForm : MetroForm
    {
        private readonly IContainer _container;

        private readonly DataSourceHelper _dataSourceHelper;

        public DeleteHouseForm()
        {
            InitializeComponent();
            _dataSourceHelper = new DataSourceHelper();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (!(cmbStreets.SelectedValue is int streetId))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите Улицу", this);
                return;
            }

            if (streetId == 0)
            {
                MessageBoxHelper.ShowWarningMessage("Критическая ошибка, улица имеет недопустимое значение. Загрузите последний бэкап",this);
                return;
            }

            var result = CheckFill(cmbHouses, "Дом");

            if (result == false)
                return;

            result = CheckFill(cmbBuildings, "Корпус");
            if (result == false)
                return;

            result = CheckFill(cmbApartmens, "Квартиру");
            if (result == false)
                return;

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();
                var location =
                    locationService.GetLocation(streetId, cmbHouses.Text, cmbBuildings.Text, cmbApartmens.Text);

                if (location == null)
                {
                    MessageBoxHelper.ShowWarningMessage("Адрес не найден",this);
                    return;
                }

                locationService.Delete(location);

                DialogResult = DialogResult.OK;
            }
        }

        private void DeleteHouseForm_Load(object sender, System.EventArgs e)
        {
            _dataSourceHelper.LoadAddresses(cmbStreets);

        }

        private bool CheckFill(ListControl comboBox, string warning)
        {
            if (comboBox.SelectedIndex != 0) 
                return true;

            MessageBoxHelper.ShowWarningMessage($"Выберите {warning}", this);
            return false;
        }

        private void cmbStreets_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cmbHouses.DataSource = null;
            cmbBuildings.DataSource = null;
            cmbApartmens.DataSource = null;

            _dataSourceHelper.StreetIndexChanged(cmbStreets, cmbHouses, x => x.HouseNumber);
        }

        private void cmbHouses_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            _dataSourceHelper.HouseIndexChanged(cmbStreets, cmbHouses, cmbBuildings, x => x.BuildingCorpus);
        }

        private void cmbBuildings_DropDown(object sender, System.EventArgs e)
        {
            _dataSourceHelper.BuildingIndexChanged(cmbStreets, cmbHouses, cmbBuildings, cmbApartmens, x => x.ApartmentNumber);
        }
    }
}
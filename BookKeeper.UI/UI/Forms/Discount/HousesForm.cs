using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.UI.Helpers;
using MetroFramework.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class HousesForm : MetroForm
    {
        private readonly IContainer _container;

        public HousesForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void HousesForm_Load(object sender, EventArgs e)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IStreetService>();

                var streets = service.GetItems().Where(x => x.IsDeleted == false).ToList();
                cmbStreets.DataSource = streets;
                cmbStreets.DisplayMember = "StreetName";
                cmbStreets.ValueMember = "Id";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(txtHouse.Text) ||
                string.IsNullOrWhiteSpace(txtBuilding.Text) ||
                string.IsNullOrWhiteSpace(txtApartment.Text))
            {
                MessageBoxHelper.ShowWarningMessage("Заполните все поля", this);
                return;
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.GetItem(x => x.HouseNumber == txtHouse.Text &&
                                                            x.BuildingCorpus == txtBuilding.Text &&
                                                            x.ApartmentNumber == txtApartment.Text &&
                                                            x.IsDeleted == false);

                if (location != null)
                {
                    MessageBoxHelper.ShowWarningMessage("Такой дом уже существует", this);
                    return;
                }

                if (cmbStreets.SelectedValue is int streetId)
                {
                    var result = locationService.Add(txtHouse.Text, txtBuilding.Text, txtApartment.Text,
                        streetId);

                    if (result != null)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }

                else
                {
                    MessageBoxHelper.ShowWarningMessage("Ошибка", this);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult =
                MessageBoxHelper.ShowConfirmMessage("Вы уверены, что хотите безвозвратно удалить данные?", this);

            if(DialogResult != DialogResult.Yes)
                return;

            using (var scope = _container.BeginLifetimeScope())
            {
                var locationService = scope.Resolve<ILocationService>();
                var location = locationService.GetItem(x => x.HouseNumber == txtHouse.Text &&
                                                            x.BuildingCorpus == txtBuilding.Text &&
                                                            x.ApartmentNumber == txtApartment.Text &&
                                                            x.IsDeleted == false);

                if (location == null)
                {
                    MessageBoxHelper.ShowWarningMessage("Дом не найден", this);
                    return;
                }

                var result = locationService.GetItemById(location.Id);
                if (result != null)
                {
                    result.IsDeleted = true;
                    locationService.Update(result);

                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.UI.Helpers;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class AddHousesForm : MetroForm
    {
        private readonly IContainer _container;
        private readonly DataSourceHelper _sourceHelper;

        public AddHousesForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
            _sourceHelper = new DataSourceHelper();
        }

        private void HousesForm_Load(object sender, EventArgs e)
        {
            _sourceHelper.LoadAddresses(cmbStreets);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (!string.IsNullOrWhiteSpace(txtAccount.Text))
            {
                try
                {
                    var account = Convert.ToInt64(txtAccount.Text);
                }
                catch (FormatException)
                {
                    MessageBoxHelper.ShowWarningMessage("Неправильный формат", this);
                    return;
                }
                catch (OverflowException)
                {
                    MessageBoxHelper.ShowWarningMessage("Число слишком большое", this);
                    return;
                }
            }

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

                    if (!string.IsNullOrWhiteSpace(txtAccount.Text))
                    {
                        var accountService = scope.Resolve<IAccountService>();
                        accountService.AddAccount(Convert.ToInt64(txtAccount.Text), result);
                    }

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
            this.Close();
        }
    }
}
using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.UI.Helpers;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IContainer = Autofac.IContainer;

//TODO Заказчик так и не ответил, нужно использовать такуб версию, или нет. После ответа ее нужно будет либо удалить, либо переделать.


namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class DiscountOnAddressForm : MetroForm
    {
        private readonly IContainer _container;

        private readonly DataSourceHelper _dataSourceHelper;

        private int _count;

        private List<decimal> _percents = new List<decimal>();

        public DiscountOnAddressForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
            _dataSourceHelper = new DataSourceHelper();
        }

        private void DiscountOnAddressForm_Load(object sender, EventArgs e)
        {
            _dataSourceHelper.LoadAddresses(cmbStreets);
            _dataSourceHelper.LoadDiscountsPercent(cmbPercent);
            _dataSourceHelper.LoadDiscountsDescription(cmbDescription);
            lblCounter.Text = _count.ToString();
        }

        private void btnSaveDiscount_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (dateFrom.Value.Date == dateTo.Value.Date)
            {
                MessageBoxHelper.ShowWarningMessage("Даты должны различаться", this);
                return;
            }

            if (!(cmbStreets.SelectedValue is int))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите улицу", this);
                return;
            }

            if (lstPeople.Items.Count == 0)
            {
                MessageBoxHelper.ShowWarningMessage("Добавте жильцов", this);
                return;
            }

            var result = CheckField(cmbHouses, "Выберите дом");
            if (result == false)
                return;

            result = CheckField(cmbBuilding, "Выберите корпус");
            if (result == false)
                return;

            result = CheckField(cmbApatmens, "Выберите улицу");
            if (result == false)
                return;

            if (cmbStreets.SelectedValue is int streetId && cmbPercent.SelectedValue is decimal percent && cmbDescription.SelectedValue is string description)
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var locationService = scope.Resolve<ILocationService>();
                    var location = locationService.GetLocation(streetId, cmbHouses.Text, cmbBuilding.Text, cmbApatmens.Text);

                    if (location == null)
                    {
                        MessageBoxHelper.ShowWarningMessage("Квартиры по такому адресу не существует", this);
                        return;
                    }

                    var accountService = scope.Resolve<IAccountService>();
                    var account = accountService.GetItem(x => x.LocationId == location.Id &&
                                                                      x.StreetId == streetId &&
                                                                x.IsDeleted == false);

                    if (account == null)
                    {
                        MessageBoxHelper.ShowWarningMessage("Счета по такому адресу не найдено", this);
                        return;
                    }

                    var discountService = scope.Resolve<IDiscountDocumentService>();
                    var occupantService = scope.Resolve<IOccupantService>();

                    foreach (var item in _percents)
                    {
                        var discounts = discountService.AddDiscountOnAddress(account.Id, item, description,
                            dateFrom.Value.Date, dateTo.Value.Date);

                        occupantService.AddOccupant(discounts.Id, location.Id, item);
                    }

                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void cmbStreets_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dataSourceHelper.StreetIndexChanged(cmbStreets, cmbHouses, x => x.HouseNumber);
        }

        private void cmbHouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dataSourceHelper.HouseIndexChanged(cmbStreets, cmbHouses, cmbBuilding, x => x.BuildingCorpus);
        }

        private void cmbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dataSourceHelper.BuildingIndexChanged(cmbStreets, cmbHouses, cmbBuilding, cmbApatmens, x => x.ApartmentNumber);
        }

        private bool CheckField(ListControl comboBox, string message)
        {
            if (string.IsNullOrWhiteSpace(comboBox.SelectedValue as string))
            {
                MessageBoxHelper.ShowWarningMessage(message, this);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbStreets.SelectedValue is int streetId && cmbPercent.SelectedValue is decimal percent &&
                cmbDescription.SelectedValue is string description)
            {
                lstPeople.Items.Add($"{percent} - {description}");

                _percents.Add(percent);

                ++_count;
            }
        }

        private void ResetValues()
        {
            cmbHouses.SelectedIndex = 0;
            cmbBuilding.SelectedIndex = 0;
            cmbApatmens.SelectedIndex = 0;
            cmbDescription.Text = string.Empty;
            cmbPercent.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstPeople.Items.Remove(lstPeople.SelectedItem);
            --_count;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            lstPeople.Items.Add("Жилец");
            _percents.Add(0);
        }
    }
}
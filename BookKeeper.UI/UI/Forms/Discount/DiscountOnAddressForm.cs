using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.UI.Helpers;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BookKeeper.UI.Models.Discount;
using MetroFramework.Controls;
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class DiscountOnAddressForm : MetroForm
    {
        private readonly IContainer _container;
        private readonly DataSourceHelper _dataSourceHelper;

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
                    var accounts = accountService.GetWithInclude(x => x.LocationId == location.Id &&
                                                                      x.StreetId == streetId &&
                                                                x.IsDeleted == false, x => x.Location);

                    var discountService = scope.Resolve<IDiscountDocumentService>();
                    var selectedAccounts = accounts.Select(x => x.Id).ToList();
                    if (!selectedAccounts.Any())
                    {
                        MessageBoxHelper.ShowConfirmMessage("Счета по данному адресу не найдены", this);
                        return;
                    }

                    var discounts = discountService.AddDiscountOnAddress(selectedAccounts, percent, description, dateFrom.Value.Date, dateTo.Value.Date);
                    if (discounts != null)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBoxHelper.ShowWarningMessage("Не удалось добавить", this);
                        return;
                    }
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
            ResetValues();
            if (cmbStreets.SelectedValue is int streetId && cmbPercent.SelectedValue is decimal percent &&
                cmbDescription.SelectedValue is string description)
            {
                lstPeople.Items.Add($"{percent} - {description}");
                lblCounter.Text = lstPeople.Items.Count.ToString();
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
        }
    }
}
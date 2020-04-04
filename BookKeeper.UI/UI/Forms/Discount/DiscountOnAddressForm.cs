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
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class DiscountOnAddressForm : MetroForm
    {
        private readonly IContainer _container;

        public DiscountOnAddressForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();

        }

        private void DiscountOnAddressForm_Load(object sender, EventArgs e)
        {
            LoadValues();
        }

        public DiscountModel DiscountModel { get; set; }

        private void btnSaveDiscount_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (dateFrom.Value.Month == dateTo.Value.Month)
            {
                MessageBoxHelper.ShowWarningMessage("Даты не могу совпадать", this);
                return;
            }

            if (cmbStreets.SelectedValue is int streetId && cmbPercent.SelectedValue is decimal percent && cmbDescription.SelectedValue is string description)
            {
                var discountToAdd = new List<DiscountDocumentEntity>();
                using (var scope = _container.BeginLifetimeScope())
                {
                    var locationService = scope.Resolve<ILocationService>();
                    var location = locationService.GetLocation(streetId, txtHouse.Text, txtBuilding.Text, txtApartment.Text);

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

                    var discounts = discountService.AddDiscountOnAddress(selectedAccounts, percent, description, dateFrom.Value, dateTo.Value);
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

        private void LoadValues()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IStreetService>();

                var streets = service.GetItems().Where(x => x.IsDeleted == false).ToList();
                cmbStreets.DataSource = streets;
                cmbStreets.DisplayMember = "StreetName";
                cmbStreets.ValueMember = "Id";

                var discountPercentService = scope.Resolve<IDiscountPercentService>();
                var discounts = discountPercentService.GetItems(x => x.IsDeleted == false);
                cmbPercent.DataSource = discounts.ToList();
                cmbPercent.DisplayMember = "Percent";
                cmbPercent.ValueMember = "Percent";

                var descriptionsService = scope.Resolve<IDiscountDescriptionService>();
                var descriptions = descriptionsService.GetItems(x => x.IsDeleted == false);

                cmbDescription.DataSource = descriptions.ToList();
                cmbDescription.DisplayMember = "Description";
                cmbDescription.ValueMember = "Description";
            }
        }
    }
}
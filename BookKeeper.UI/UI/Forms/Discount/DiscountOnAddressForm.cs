﻿using Autofac;
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
            if (cmbStreets.SelectedValue is int streetId && cmbPercent.SelectedValue is decimal percent && cmbDescription.SelectedValue is string description)
            {
                var accountsToUpdate = new List<AccountEntity>();
                using (var scope = _container.BeginLifetimeScope())
                {
                    var locationService = scope.Resolve<ILocationService>();
                    var location =
                        locationService.GetLocation(streetId, txtHouse.Text, txtBuilding.Text, txtApartment.Text);

                    if (location == null)
                    {
                        MessageBoxHelper.ShowWarningMessage("Квартиры по такому адресу не существует", this);
                        return;
                    }

                    var accountService = scope.Resolve<IAccountService>();
                    var accounts = accountService.GetWithInclude(x => x.LocationId == location.Id &&
                                                                x.IsDeleted == false,x=>x.Location).ToList();

                    foreach (var account in accounts)
                    {
                        account.DiscountDocuments.Add(new DiscountDocumentEntity
                        {
                            AccountId = account.Id,
                            Type = DiscountType.Address,
                            Percent = percent,
                            Description = description,
                            StartDate = DateTime.Now
                        });

                        accountsToUpdate.Add(account);
                    }
                    accountService.Update(accountsToUpdate);

                    var fullAddress = accounts.Select(x => x.Location).FirstOrDefault();
                    if (fullAddress != null)
                    {
                        DiscountModel = new DiscountModel
                        {
                            Type = DiscountType.Address,
                            Address =
                                $"{fullAddress.Street.StreetName} Дом.{fullAddress.HouseNumber} Кр.{fullAddress.BuildingCorpus} Кв.{fullAddress.ApartmentNumber}",
                            Price = percent.ToString(CultureInfo.CurrentCulture),
                            Description = description,
                        };
                        DialogResult = DialogResult.OK;
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
﻿using Autofac;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.UI.Helpers;
using BookKeeper.UI.Models.Discount;
using MetroFramework.Forms;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class DiscountAccountItemForm : MetroForm
    {
        private readonly IContainer _container;

        public DiscountAccountItemForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void DiscountAccountItem_Load(object sender, EventArgs e)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var percentService = scope.Resolve<IDiscountPercentService>();
                var percents = percentService.GetItems(x => x.IsDeleted == false).ToList();

                var descriptionService = scope.Resolve<IDiscountDescriptionService>();
                var descriptions = descriptionService.GetItems(x => x.IsDeleted == false).ToList();

                cboPercent.DataSource = percents;
                cboPercent.DisplayMember = "Percent";
                cboPercent.ValueMember = "Percent";

                cboDescription.DataSource = descriptions;
                cboDescription.DisplayMember = "Description";
                cboDescription.ValueMember = "Description";
            }
        }

        public DiscountModel DiscountModel { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccount.Text))
            {
                MessageBoxHelper.ShowWarningMessage("Аккаунт не может быть пустым",this);
                return;
            }

            if (dateFrom.Value.Month == dateTo.Value.Month)
            {
                MessageBoxHelper.ShowWarningMessage("Даты не могу совпадать",this);
                return;
            }

            decimal percent = 0;
            long account = 0;
            var description = string.Empty;
            try
            {
                percent = Convert.ToDecimal(cboPercent.SelectedValue);
                account = Convert.ToInt64(txtAccount.Text);
                description = (string)cboDescription.SelectedValue;
            }
            catch (FormatException)
            {
                MessageBoxHelper.ShowWarningMessage("Допустимы только цифры", this);
            }
            catch (InvalidCastException)
            {
                MessageBoxHelper.ShowWarningMessage("Значение слишком большое", this);
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                var accountService = scope.Resolve<IAccountService>();
                var accountItem = accountService.GetItem(x => x.Account == account);
                if (accountItem == null)
                {
                    MessageBoxHelper.ShowWarningMessage("Такого счета не существует", this);
                    return;
                }

                var discountService = scope.Resolve<IDiscountDocumentService>();
                var discountOnAccount = discountService.AddDiscountOnAccount(accountItem.Id, percent, description,dateFrom.Value,dateTo.Value);
                if (discountOnAccount == null)
                {
                    MessageBoxHelper.ShowWarningMessage("Не удалось добавить", this);
                    return;
                }

                DiscountModel = new DiscountModel
                {
                    Type = DiscountType.PersonalAccount,
                    Account = account.ToString(),
                    Price = percent.ToString(CultureInfo.CurrentCulture),
                    Description = description,
                    DiscountId = discountOnAccount.Id
                };

                DialogResult = DialogResult.OK;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Discount;
using MetroFramework.Forms;
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms
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
                var percentService = _container.Resolve<IDiscountPercentService>();
                var percents = percentService.GetItems(x => x.IsDeleted == false).ToList();

                var descriptionService = _container.Resolve<IDiscountDescriptionService>();
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
                MessageBox.Show("Аккаунт не может быть пустым");
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
                MessageBox.Show("Допустимы только цифры");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Допустимы только цифры");
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                var accountService = scope.Resolve<IAccountService>();
                var accountItem = accountService.GetItem(x => x.Account == account);
                if (accountItem == null)
                {
                    MessageBox.Show("Такого счета не существует");
                    return;
                }

                var discountService = scope.Resolve<IDiscountDocumentService>();
                var discountOnAccount = discountService.AddDiscountOnAccount(accountItem.Id, percent, description);
                if (discountOnAccount == null)
                {
                    MessageBox.Show("Не удалось добавить");
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
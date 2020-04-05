using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.UI.Helpers;
using MetroFramework.Forms;
using System;
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
            var autoCompleteSourceHelper = new AutoCompleteSourceHelper();
            autoCompleteSourceHelper.FillAutoSource(txtAccount);

            using (var scope = _container.BeginLifetimeScope())
            {
                var percentService = scope.Resolve<IDiscountPercentService>();
                var percents = percentService.GetItems(x => x.IsDeleted == false).ToList();

                var descriptionService = scope.Resolve<IDiscountDescriptionService>();
                var descriptions = descriptionService.GetItems(x => x.IsDeleted == false).ToList();

                var accountService = scope.Resolve<IAccountService>();
                var accounts = accountService.GetItems(x => x.IsDeleted == false).ToList();


                cmbPercent.DataSource = percents;
                cmbPercent.DisplayMember = "Percent";
                cmbPercent.ValueMember = "Percent";

                cmbDescription.DataSource = descriptions;
                cmbDescription.DisplayMember = "Description";
                cmbDescription.ValueMember = "Description";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(txtAccount.Text))
            {
                MessageBoxHelper.ShowWarningMessage("Аккаунт не может быть пустым", this);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbPercent.SelectedText))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите  скидку", this);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbDescription.SelectedText))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите описание",this);
                return;
            }

            decimal percent = 0;
            long account = 0;
            var description = string.Empty;
            try
            {
                percent = Convert.ToDecimal(cmbPercent.SelectedValue);
                account = Convert.ToInt64(txtAccount.Text);
                description = cmbDescription.SelectedValue as string;
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
                var discountOnAccount = discountService.AddDiscountOnAccount(accountItem.Id, percent, description);
                if (discountOnAccount == null)
                {
                    MessageBoxHelper.ShowWarningMessage("Не удалось добавить", this);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }
    }
}
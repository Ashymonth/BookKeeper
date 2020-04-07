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

            var dataSource = new DataSourceHelper();
            dataSource.LoadDiscountsPercent(cmbPercent);
            dataSource.LoadDiscountsDescription(cmbDescription);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(txtAccount.Text))
            {
                MessageBoxHelper.ShowWarningMessage("Аккаунт не может быть пустым", this);
                return;
            }

            

            if (!(cmbPercent.SelectedValue is decimal percent))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите  скидку", this);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbDescription.SelectedValue as string))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите описание", this);
                return;
            }

            long account = 0;
            var description = string.Empty;
            try
            {
                percent = Convert.ToDecimal(cmbPercent.Text);
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
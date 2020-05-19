using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.UI.Helpers;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class DiscountAccountItemForm : MetroForm
    {
        private readonly IContainer _container;

        private List<Discount> _discounts = new List<Discount>();

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

            var endDate = chkUnlimitedLastDate.Checked ? DateTime.MaxValue : dateTo.Value.Date;

            if (string.IsNullOrWhiteSpace(txtAccount.Text))
            {
                MessageBoxHelper.ShowWarningMessage("Аккаунт не может быть пустым", this);
                return;
            }

            if (!(cmbPercent.SelectedValue is decimal))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите  скидку", this);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbDescription.SelectedValue as string))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите описание", this);
                return;
            }

            if (dateFrom.Value.Date == dateTo.Value.Date && chkUnlimitedLastDate.Checked == false)
            {
                MessageBoxHelper.ShowWarningMessage("Даты должны различаться", this);
                return;
            }


            if (_discounts.Count == 0)
            {
                MessageBoxHelper.ShowWarningMessage("Должен быть хотя бы 1 проживающий в квартире", this);
                return;
            }

            var occupants = _discounts.Select(x => x.Price).FirstOrDefault(x => x != 0);
            if (occupants == 0)
            {
                MessageBoxHelper.ShowWarningMessage("Должен быть хотя бы 1 льготник", this);
                return;
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                var accountService = scope.Resolve<IAccountService>();
                var accountItem = accountService.GetItem(x => x.Account == Convert.ToInt64(txtAccount.Text));
                if (accountItem == null)
                {
                    MessageBoxHelper.ShowWarningMessage("Такого счета не существует", this);
                    return;
                }

                var discountService = scope.Resolve<IDiscountDocumentService>();
                var occupantService = scope.Resolve<IOccupantService>();

                foreach (var discount in _discounts)
                {
                    var discountOnAccount = discountService.AddDiscountOnAccount(accountItem.Id, discount.Price, discount.Description, dateFrom.Value.Date, endDate);
                    occupantService.AddOccupant(discountOnAccount.Id, accountItem.Id, discount.Price);
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void btnAddOccupant_Click(object sender, EventArgs e)
        {
            lstOccupants.Items.Add("Жилец");
            _discounts.Add(new Discount()
            {
                Price = 0,
                Description = string.Empty
            });
        }

        private void btnAddOccupantWithDiscount_Click(object sender, EventArgs e)
        {
            lstOccupants.Items.Add($"{cmbPercent.Text} - {cmbDescription.Text}");
            _discounts.Add(new Discount
            {
                Price = Convert.ToDecimal(cmbPercent.Text),
                Description = cmbDescription.Text
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstOccupants.Items.Remove(lstOccupants.SelectedItem);
        }
    }

    public class Discount
    {
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
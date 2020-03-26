using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Discount;
using MetroFramework.Forms;
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms.Discount
{
    public partial class DiscountPercentItem : MetroForm
    {
        private readonly IContainer _container;
        public DiscountPercentItem()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void DiscountAndDescriptionItem_Load(object sender, EventArgs e)
        {
           LoadItems();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            try
            {
                var check = Convert.ToDecimal(txtDiscountPercent.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Допустимы только цифры");
                return;
            }

            var number = Convert.ToDecimal(txtDiscountPercent.Text,CultureInfo.InvariantCulture);

            if (number == 0 || number <= -1)
            {
                MessageBox.Show("Значение должно быть больше нуля");
                return;
            }

            if (txtDiscountPercent.Text.Length > 3 || number > 100)
            {
                MessageBox.Show("Значение не может быть больше 100");
                return;
            }


            if (string.IsNullOrWhiteSpace(txtDiscountPercent.Text))
            {
                MessageBox.Show("Заполните поле");
                return;
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                var percentService = scope.Resolve<IDiscountPercentService>();
                percentService.AddDiscountPercent(txtDiscountPercent.Text);

            }
            LoadItems();
        }

        private void LoadItems()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var percentService = scope.Resolve<IDiscountPercentService>();
                var percents = percentService.GetItems(x => x.IsDeleted == false);

                lstPercent.DataSource = percents.ToList();
                lstPercent.DisplayMember = "Percent";
                lstPercent.ValueMember = "Id";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPercent.SelectedItem is DiscountPercentEntity entity)
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var descriptionService = scope.Resolve<IDiscountPercentService>();
                    var result = descriptionService.GetItemById(entity.Id);
                    if (result != null)
                    {
                        descriptionService.Delete(result);
                        LoadItems();
                    }
                }
            }
        }
    }
}

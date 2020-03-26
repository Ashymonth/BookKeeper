using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Discount;
using MetroFramework.Forms;
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms
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

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(txtDiscountPercent.Text))
            {
                MessageBox.Show("Заполните поле");
                return;
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                var percentService = scope.Resolve<IDiscountPercentService>();
                percentService.AddDiscountPercent(txtDiscountPercent.Text);

                DialogResult = DialogResult.OK;
            }
        }
    }
}

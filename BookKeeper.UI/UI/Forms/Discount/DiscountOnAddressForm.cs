using System;
using BookKeeper.Data.Infrastructure;
using MetroFramework.Forms;
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

        private void DiscountItemForm_Load(object sender, EventArgs e)
        {
            LoadStreets();
        }

        private void btnSaveDiscount_Click(object sender, EventArgs e)
        {

        }

        #region Load Combo box value

        public void LoadStreets()
        {
            
        }

        #endregion
    }
}

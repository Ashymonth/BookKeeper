using BookKeeper.Data.Models;
using MetroFramework.Forms;

namespace BookKeeper.UI.UI.Forms
{
    public partial class AccountDetailsForm : MetroForm
    {
        public AccountDetailsForm()
        {
            InitializeComponent();
        }

        public AccountDetailsModel AccountDetailsModel { get; set; }

        private void AccountDetailsForm_Load(object sender, System.EventArgs e)
        {
            if (AccountDetailsModel == null)
                return;

            txtAccount.Text = AccountDetailsModel.Account;
            txtStreet.Text = AccountDetailsModel.Street;
            txtHouse.Text = AccountDetailsModel.House;
            txtBuilding.Text = AccountDetailsModel.Building;
            txtApartment.Text = AccountDetailsModel.Apartment;
            txtAccrued.Text = AccountDetailsModel.Accrued;
            txtRecived.Text = AccountDetailsModel.Received;
            txtRate.Text = AccountDetailsModel.Rate;
            txtDiscount.Text = AccountDetailsModel.Discount;
        }
    }
}

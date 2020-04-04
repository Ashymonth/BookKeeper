using BookKeeper.UI.Models.Account;
using MetroFramework.Forms;

namespace BookKeeper.UI.UI.Forms.Account
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
            txtAccountType.Text = AccountDetailsModel.AccountType;
        }
    }
}

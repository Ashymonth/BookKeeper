using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.UI.Models.Account;
using MetroFramework.Forms;

namespace BookKeeper.UI.UI.Forms.Account
{
    public partial class AccountDetailsForm : MetroForm
    {
        private readonly IContainer _container;

        public AccountDetailsForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
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

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.None;
        }

        private void metroButton2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using MetroFramework.Forms;

namespace BookKeeper.UI.UI.Forms
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
        public AccountEntity Account { get; set; }

        private void AccountDetailsForm_Load(object sender, System.EventArgs e)
        {
            if (Account == null)
                return;

            txtAccount.Text = Account.Account.ToString();
            txtStreet.Text = Account.Location.Street.StreetName;
            txtHouse.Text = Account.Location.HouseNumber;
            txtBuilding.Text = Account.Location.BuildingCorpus;
            txtApartment.Text = Account.Location.ApartmentNumber;
            txtAccrued.Text = Account.PaymentDocuments.FirstOrDefault()?.Accrued.ToString(CultureInfo.CurrentCulture);
            txtRecived.Text = Account.PaymentDocuments.FirstOrDefault()?.Received.ToString(CultureInfo.CurrentCulture);
        }
        //txtAccount.Text = AccountDetailsModel.Account;
        //txtStreet.Text = AccountDetailsModel.Street;
        //txtHouse.Text = AccountDetailsModel.House;
        //txtBuilding.Text = AccountDetailsModel.Building;
        //txtApartment.Text = AccountDetailsModel.Apartment;
        //txtAccrued.Text = AccountDetailsModel.Accrued;
        //txtRecived.Text = AccountDetailsModel.Received;
        //txtRate.Text = AccountDetailsModel.Rate;
        //txtDiscount.Text = AccountDetailsModel.Discount;
        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.None;

            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IAccountService>();
                service.Update(Account);

                DialogResult = DialogResult.OK;
            }
        }
    }
}

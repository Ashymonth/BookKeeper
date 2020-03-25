using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Rate;
using BookKeeper.Data.Services.Load;
using BookKeeper.UI.UI.Forms;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Services.EntityService;

namespace BookKeeper.UI
{
    public partial class Form1 : MetroForm
    {
        #region Initialize

        private readonly Autofac.IContainer _container;
        private readonly ProgressForm _form = new ProgressForm();
        private string[] _files;

        public Form1()
        {

            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAddresses();
            LoadRates();
        }

        #endregion

        #region Tool Menu

        private void btnFiles_Click(object sender, EventArgs e)
        {
            cntFilesMenu.Show(btnFiles, 0, btnFiles.Height);
        }

        private void btnLoadBase_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = @"Html files(*.xls;*.xls)|*.xlsx;*xlsx|All files(*.*)|*.*";
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                _files = dialog.FileNames;
            }

            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync("Excel");
            }

            _form.ShowDialog();

        }

        private void btnLoadPayments_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = @"Html files(*.html;*.htm)|*.html;*htm|All files(*.*)|*.*";
                dialog.Multiselect = true;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                _files = dialog.FileNames;
            }

            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync("Html");
            }

            _form.ShowDialog();
        }

        #endregion

        #region MonthReportListView

        #region Buttons

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchModel searchModel = null;
            try
            {
                searchModel = new SearchModel
                {
                    StreetId = (int)cmbStreet.SelectedValue,
                    AccountType = Convert(cmbPersonalAccountType.SelectedIndex),
                    HouseNumber = txtHouse.Text,
                    BuildingNumber = txtBuilding.Text,
                    ApartmentNumber = txtApartment.Text,
                    IsArchive = metroCheckBox1.Checked
                };
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите улицу");
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ISearchService>();
                var result = service.FindAccounts(searchModel);

                if (result != null)
                {
                    LoadAccountsInfo(result);
                }
            }
        }

        #endregion

        #region Helps Method

        private void LoadAccountsInfo(IEnumerable<AccountEntity> accountEntities)
        {
            lvlMonthReport.Clear();
            lvlMonthReport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvlMonthReport.Columns.Add("Счет");

            var accounts = accountEntities.ToList();

            var dates = accounts.Select(x => x.PaymentDocuments).FirstOrDefault();
            if (dates == null || accounts.Count == 0)
            {
                return;
            }

            foreach (var date in dates)
            {
                lvlMonthReport.Columns.Add(date.PaymentDate.ToShortDateString());
            }

            foreach (var accountEntity in accounts)
            {
                foreach (var documentEntity in accountEntity.PaymentDocuments)
                {
                    lvlMonthReport.Items.Add(new ListViewItem(new[]
                    {
                        accountEntity.Account.ToString(),
                        documentEntity.Accrued.ToString(CultureInfo.CurrentCulture),
                    }));
                }
            }
        }

        private static AccountType Convert(int index)
        {
            return index == 0 ? AccountType.Municipal : AccountType.Private;
        }


        #endregion


        #region LoadStartValue

        private void LoadAddresses()
        {
            try
            {
                cmbPersonalAccountType.SelectedIndex = 0;

                using (var scope = _container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<IStreetService>();

                    var result = service.GetItems(x => x.IsDeleted == false).ToList();

                    cmbStreet.DataSource = result;
                    cmbStreet.DisplayMember = "StreetName";
                    cmbStreet.ValueMember = "Id";
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion

        #endregion

        #region RateListView

        #region buttons

        private void btnAddRate_Click(object sender, EventArgs e)
        {
            using (var rate = new RateItemForm())
            {
                var dialogResult = rate.ShowDialog(this);

                if (dialogResult == DialogResult.OK)
                {
                    LoadItem(rate.RateModel);
                }
            }
        }

        private void btnDeleteRate_Click(object sender, EventArgs e)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IRateDocumentService>();
                var t = lvlRates.Items;
                var document = service.GetItemById((int)lvlRates.FocusedItem.Tag);

            }
        }

        #endregion

        #region Helps Method

        private void LoadItem(RateModel model)
        {
            if (model == null)
                return;

            var listViewItem = new ListViewItem(new[]
                {
                    model.Street,
                    model.House,
                    model.Building,
                    model.Price,
                    model.Description,
                })
            { Tag = model.RateId };

            lvlRates.Items.Add(listViewItem);
        }



        #endregion

        #endregion

        #region DiscountListView

        #region Buttons

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountAddressItemForm())
            {
                form.ShowDialog();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountAccountItemForm())
            {
                form.ShowDialog();
            }
        }
        #endregion

        #region Load start value
        private void LoadRates()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var documentService = scope.Resolve<IRateDocumentService>();
                var addressService = scope.Resolve<IStreetService>();
                var locationService = scope.Resolve<ILocationService>();

                var rates = documentService.GetWithInclude(x => x.RatesDescription);
                foreach (var rate in rates)
                {
                    foreach (var descriptionEntity in rate.RatesDescription)
                    {
                        var street = addressService.GetItem(x => x.Id == rate.StreetId);
                        var location = locationService.GetItem(x => x.Id == rate.LocationId);

                        var listView = new ListViewItem(new[]
                        {
                            street.StreetName,
                            location.HouseNumber,
                            location.BuildingCorpus,
                            rate.Price.ToString(CultureInfo.CurrentCulture),
                            descriptionEntity.Description
                        })
                        {Tag = rate};

                        lvlRates.Items.Add(listView);
                    }
                }
            }
        }

        #endregion

        #endregion

        #region BackgroundWorker

        private void backgroundWorker1_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var options = e.Argument as string;
            foreach (var file in _files)
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var service = scope.ResolveNamed<IDataLoader>(options);
                    service.LoadData(file);
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _form.Dispose();
        }
        #endregion

        private void lvlMonthReport_DoubleClick(object sender, EventArgs e)
        {
            var item = lvlMonthReport.FocusedItem;
            if (item.Text.Length != 8)
                return;

            var accountNumber = item.Text;
            AccountEntity accountDetails = null;
            try
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<IAccountService>();
                    accountDetails = service.GetWithInclude(x => x.Account == System.Convert.ToInt64(accountNumber),
                        x => x.Location, x => x.PaymentDocuments).FirstOrDefault();
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show(exception.Message);
            }

            if (accountDetails == null)
            {
                MessageBox.Show("Аккаунт не найден");
                return;
            }

            var accountPayment = accountDetails.PaymentDocuments.FirstOrDefault();


            using (var form = new AccountDetailsForm())
            {
                form.AccountDetailsModel = new AccountDetailsModel
                {
                    Account = accountDetails.Account.ToString(),
                    Street = cmbStreet.Text,
                    House = accountDetails.Location.HouseNumber,
                    Building = accountDetails.Location.BuildingCorpus,
                    Apartment = accountDetails.Location.ApartmentNumber,
                    Accrued = accountPayment?.Accrued.ToString(CultureInfo.CurrentCulture),
                    Received = accountPayment?.Received.ToString(CultureInfo.CurrentCulture)
                };
                form.ShowDialog();
            }
        }

        private void btnShowDebtor_Click(object sender, EventArgs e)
        {

        }
    }
}
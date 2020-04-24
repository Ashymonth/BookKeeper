using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Infrastructure.Formats;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.Data.Services.EntityService.Rate;
using BookKeeper.Data.Services.Export;
using BookKeeper.Data.Services.Load;
using BookKeeper.UI.Helpers;
using BookKeeper.UI.Models.Account;
using BookKeeper.UI.UI.Forms;
using BookKeeper.UI.UI.Forms.Account;
using BookKeeper.UI.UI.Forms.Discount;
using BookKeeper.UI.UI.Forms.Houses;
using BookKeeper.UI.UI.Forms.Rate;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SortOrder = System.Windows.Forms.SortOrder;

namespace BookKeeper.UI
{
    public partial class MainForm : MetroForm
    {
        #region Initialize

        private readonly IContainer _container;
        private ProgressForm _form;
        private string[] _files;
        private int _columnTotalIndex;
        private bool _isColumnCreate = false;

        private static readonly int PersonalAccountLength =
            System.Convert.ToInt32(ConfigurationManager.AppSettings["AccountLenght"]);

        private const string AddressTemplate = "{0} Дом: {1} Корпус: {2} Квартира: {3}";
        private readonly DataSourceHelper _dataSourceHelper;
        private readonly AutoCompleteSourceHelper _sourceHelper;

        public MainForm()
        {
            InitializeComponent();

            if (DateTime.Now.Date >= DateTime.Parse("29.04.2020") &&
                ConfigurationManager.AppSettings["DefaultPaymentDate"] == "1")
            {
                Environment.Exit(1);
            }

            _container = AutofacConfiguration.ConfigureContainer();

            _dataSourceHelper = new DataSourceHelper();

            _sourceHelper = new AutoCompleteSourceHelper();

            cmbPersonalAccountType.SelectedIndex = 0;

            var loader = new DefaultRateLoader();

            try
            {
                loader.LoadAndCheckDefaultRate();
            }
            catch (FormatException)
            {
                MessageBoxHelper.ShowWarningMessage("Конфигурационный файл был поврежден, исправте его", this);
                return;
            }
            catch (Exception exception)
            {
                MessageBoxHelper.ShowWarningMessage(exception.Message, this);
            }

            tabpage.SelectedTab = tbpMonthReport;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var backUpService = scope.Resolve<IBackupService>();
                backUpService.CreateBackUpInAWeek();
            }

            _dataSourceHelper.LoadAddresses(cmbStreets);
            _dataSourceHelper.LoadAddresses(cmbTotalReportStreets);
            LoadRates();
            LoadDiscounts();
            LoadAccounts();
            SetDoubleBufferForListView();
        }

        #endregion

        #region Loads start value

        private void LoadAddresses()
        {
            try
            {
                cmbPersonalAccountType.SelectedIndex = 0;

                using (var scope = _container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<IStreetService>();

                    var result = service.GetWithInclude(x => x.IsDeleted == false, x => x.Locations).ToList();

                    cmbStreets.DataSource = result;
                    cmbStreets.DisplayMember = "StreetName";
                    cmbStreets.ValueMember = "Id";

                    cmbTotalReportStreets.DataSource = result;
                    cmbTotalReportStreets.DisplayMember = "StreetName";
                    cmbTotalReportStreets.ValueMember = "Id";
                }
            }
            catch (SqlException)
            {
                MessageBoxHelper.ShowWarningMessage("Не удалось загрузить адреса", this);
            }
        }

        private void LoadRates(bool dontShowArchive = true)
        {
            lvlRates.Items.Clear();
            using (var scope = _container.BeginLifetimeScope())
            {
                var documentService = scope.Resolve<IRateService>();
                var locationService = scope.Resolve<ILocationService>();

                var rates = documentService.GetWithInclude(x => x.AssignedLocations);
                if (rates == null)
                    return;

                foreach (var rate in rates)
                {
                    if (rate.IsArchive && dontShowArchive)
                        continue;

                    if (rate.IsDeleted)
                        continue;

                    foreach (var descriptionEntity in rate.AssignedLocations)
                    {
                        var location = locationService.GetItem(x => x.Id == descriptionEntity.LocationRefId);
                        if (location == null)
                            continue;

                        var listView = new ListViewItem(new[]
                            {
                                location.Street.StreetName,
                                location.HouseNumber,
                                location.BuildingCorpus,
                                rate.Price.ToString(CultureInfo.CurrentCulture),
                                rate.Description,
                                rate.StartDate.ToShortDateString(),
                                rate.EndDate.ToShortDateString()
                            })
                        { Tag = rate };

                        if (rate.IsArchive)
                            listView.SubItems.Add(rate.EndDate.ToShortDateString());

                        lvlRates.Items.Add(listView);
                    }
                }
            }
        }

        private void LoadDiscounts(bool dontShowArchive = true)
        {
            lvlDiscounts.Items.Clear();

            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var discounts = discountService.GetWithInclude(x => x.IsDeleted == false,
                    x => x.Account,
                    x => x.Account.Location,
                    x => x.Account.Location.Street);


                if (discounts != null)
                {
                    var list = new List<ListViewItem>();
                    long accountId = 0;
                    foreach (var discount in discounts)
                    {
                        if (discount.AccountId == accountId)
                            continue;

                        var percents = discounts.Where(x => x.AccountId == discount.AccountId)
                            .Select(x => x.Percent.ToString(CultureInfo.CurrentCulture).Replace(",00", " ")).ToArray();

                        var descriptions = discounts.Where(x => x.AccountId == discount.AccountId)
                            .Select(x => x.Description).Distinct();

                        var newDescription = descriptions.Select(description => description + " ").ToArray();


                        if (discount.IsArchive && dontShowArchive)
                            continue;

                        if (discount.IsDeleted)
                            continue;

                        var discountType =
                            discount.Type == DiscountType.PersonalAccount ? "Счет" : "Адрес";

                        var addressAndAccount =
                            $"{discount.Account.Location.Street.StreetName} Дом: " +
                            $"{discount.Account.Location.HouseNumber} Корпус: " +
                            $"{discount.Account.Location.BuildingCorpus} Кваритра: " +
                            $"{discount.Account.Location.ApartmentNumber} Счет: " +
                            $"{discount.Account.Account.ToString(CultureInfo.CurrentCulture)}";

                        var listView = new ListViewItem(new[]
                        {
                            discountType, addressAndAccount,
                            $" Колличество жителей - {percents.Count()} " +
                            $" {string.Join("",percents)}",
                            $"{string.Join("",newDescription)}",
                            discount.StartDate.ToShortDateString(),
                            discount.EndDate.ToShortDateString()
                        })
                        {
                            Tag = discount
                        };
                        if (discount.IsArchive)
                        {
                            listView.SubItems.Add(discount.EndDate.ToShortDateString());
                        }

                        list.Add(listView);
                        accountId = discount.AccountId;
                    }

                    lvlDiscounts.Items.AddRange(list.ToArray());
                }
            }
        }

        private void LoadAccounts()
        {
            _sourceHelper.FillAutoSource(txtAccount);
        }

        private void SetDoubleBufferForListView()
        {
            lvlMonthReport.DoubleBuffered(true);
            lvlTotalReport.DoubleBuffered(true);
            lvlRates.DoubleBuffered(true);
            lvlDiscounts.DoubleBuffered(true);
        }

        #endregion

        #region Tool Menu

        #region toolstrip buttons

        private void btnFiles_Click(object sender, EventArgs e)
        {
            cntFilesMenu.Show(btnFiles, 0, btnFiles.Height);
        }

        private void btnDataBase_Click(object sender, EventArgs e)
        {
            cntDatabase.Show(btnDataBase, 0, btnDataBase.Height);
        }
        private void btnHouses_Click(object sender, EventArgs e)
        {
            cntHouses.Show(btnHouses, 0, btnHouses.Height);
        }

        private void btnAddDiscounts_Click(object sender, EventArgs e)
        {
            cntDiscounts.Show(btnAddDiscounts, 0, btnAddDiscounts.Height);
        }

        private void btnRates_Click(object sender, EventArgs e)
        {
            cntRates.Show(btnRates, 0, btnRates.Height);
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            cntAccounts.Show(btnAccounts, 0, btnAccounts.Height);
        }

        #endregion

        #region Base and payments

        private void btnLoadBase_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = @"Excel files(*.xls;*.xls)|*.xlsx;*xlsx|All files(*.*)|*.*";
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                _files = dialog.FileNames;

            }

            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync(LoaderType.Excel);
            }

            _form = new ProgressForm();
            _form.ShowDialog(this);
            LoadAddresses();
            LoadAccounts();
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
                backgroundWorker1.RunWorkerAsync(LoaderType.Html);

                _form = new ProgressForm();
                _form.ShowDialog(this);
            }
        }

        #endregion

        #region BackUp

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var backupService = scope.Resolve<IBackupService>();

                    var file = backupService.CreateBackup();

                    MessageBoxHelper.ShowCompeteMessage($"Бэкап создан {file}", this);
                }
            }
            catch (SqlException)
            {
                MessageBoxHelper.ShowWarningMessage("У программы нет доступа для запси файлов на данный диск",
                    this);
            }
            catch (FileLoadException)
            {
                MessageBoxHelper.ShowWarningMessage("У программы нет доступа для запси файлов на данный диск", this);
            }
            catch (Exception exception)
            {
                MessageBoxHelper.ShowWarningMessage(exception.Message, this);
            }
        }

        private void btnLoadFromBackup_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = @"SQL SERVER database backup files|*.bak";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var backupService = scope.Resolve<IBackupService>();

                        backupService.RestoreFromBackup(dialog.FileName);

                        MessageBoxHelper.ShowCompeteMessage("Успешно", this);
                    }

                    LoadAddresses();
                    LoadRates();

                }
                catch (FileNotFoundException)
                {
                    MessageBoxHelper.ShowWarningMessage("Файл не найден", this);
                }
                catch (NullReferenceException)
                {
                    MessageBoxHelper.ShowWarningMessage("Файл пуст", this);
                }
                catch (SqlException exception)
                {
                    MessageBoxHelper.ShowWarningMessage(exception.Message, this);
                    MessageBoxHelper.ShowWarningMessage("Не удалось восстановить", this);
                }
                catch (Exception exception)
                {
                    MessageBoxHelper.ShowWarningMessage(exception.Message, this);
                }
            }
        }

        #endregion

        #region Houses

        private void btnAddHouse_Click(object sender, EventArgs e)
        {
            using (var form = new AddHousesForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    MessageBoxHelper.ShowCompeteMessage("Успешно", this);
            }
        }

        private void btnDeleteHouse_Click(object sender, EventArgs e)
        {
            using (var form = new DeleteHouseForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    MessageBoxHelper.ShowCompeteMessage("Успешно", this);
            }
        }

        #endregion

        #region Accounts

        private void btnShowDebtorInDateRange_Click(object sender, EventArgs e)
        {
            var debtorsCount = 0;

            ResetColors(lvlMonthReport);
            if (_isColumnCreate == false)
                _columnTotalIndex = lvlMonthReport.Columns.Add(new ColumnHeader() { Text = "Всего", Width = 100 });
            _isColumnCreate = true;

            using (var scope = _container.BeginLifetimeScope())
            {
                var calculateService = scope.Resolve<ICalculationService>();

                foreach (ListViewItem listViewItem in lvlMonthReport.Items)
                {
                    try
                    {
                        decimal totalPayments = 0;
                        decimal received = 0;
                        if (!(listViewItem.Tag is DebtorModel account))
                            continue;

                        foreach (var payment in account.Account.PaymentDocuments.Where(x =>
                            x.PaymentDate.Date >= dateFrom.Value.Date && x.PaymentDate.Date <= dateTo.Value.Date))
                        {
                            received += payment.Received;

                            var result = calculateService.CalculateDebt(account.AccountsCount, account.Account.Id, account.Account.Location,
                                payment.Received, payment.PaymentDate);

                            totalPayments += result;
                        }

                        if (_columnTotalIndex != -1)
                            listViewItem.SubItems[_columnTotalIndex].Text = (received.ToString(CultureInfo.CurrentCulture));

                        if (totalPayments >= 0)
                            continue;

                        listViewItem.UseItemStyleForSubItems = false;
                        listViewItem.SubItems[0].BackColor = Color.LightCoral;
                        debtorsCount++;

                    }

                    catch (NullReferenceException)
                    {
                        MessageBoxHelper.ShowWarningMessage(
                            "Тариф по умолчанию был удален, дальнейшие рачеты невозможны. Перезапустите программу", this);
                        return;
                    }
                }
            }
            if (debtorsCount == 0)
            {
                MessageBoxHelper.ShowCompeteMessage("Счетов с задолжностями нет", this);
                return;
            }
        }

        private void btnShowNewAccountsInRange_Click(object sender, EventArgs e)
        {
            var newAccountsCount = 0;
            foreach (ListViewItem listViewItem in lvlMonthReport.Items)
            {
                if (listViewItem.Tag is AccountEntity account)
                {
                    if (account.IsNew)
                    {
                        listViewItem.UseItemStyleForSubItems = false;
                        listViewItem.SubItems[0].BackColor = Color.LightGreen;
                        newAccountsCount++;
                    }
                }
            }

            if (newAccountsCount == 0)
            {
                MessageBoxHelper.ShowCompeteMessage("Новых счетов нет", this);
                return;
            }

        }

        private void btnResetMonthReportColor_Click(object sender, EventArgs e)
        {
            ResetColors(lvlMonthReport);
        }

        #endregion

        #endregion

        #region MonthReportListView

        #region Buttons

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (dateFrom.Value.Date > dateTo.Value.Date)
            {
                MessageBoxHelper.ShowWarningMessage("Дата начала не может быть больше конца", this);
                return;
            }

            if (cmbStreets.SelectedValue is int streetId)
            {
                var searchModel = new SearchModel
                {
                    StreetId = streetId,
                    Account = ValidPersonalAccount(txtAccount.Text),
                    AccountType = Convert(cmbPersonalAccountType.SelectedIndex),
                    HouseNumber = cmbHouses.SelectedIndex == 0 ? string.Empty : cmbHouses.Text,
                    BuildingNumber = cmbBuildings.SelectedIndex == 0 ? string.Empty : cmbBuildings.Text,
                    ApartmentNumber = cmbApartmens.SelectedIndex == 0 ? string.Empty : cmbApartmens.Text,
                    IsArchive = chkIsArchive.Checked,
                    IsNoneBuilding = chkIsBuilding.Checked,
                    From = dateFrom.Value,
                    To = dateTo.Value
                };

                _isColumnCreate = false;

                CreateColumns(dateFrom.Value.Date, dateTo.Value.Date);

                try
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var service = scope.Resolve<ISearchService>();
                        var searchResult = service.FindAccounts(searchModel);

                        if (searchResult != null && searchResult.Any())
                        {
                            LoadAccountsInfo(searchResult, scope);
                        }
                        else
                        {
                            MessageBoxHelper.ShowWarningMessage("Ничего не найдено", this);
                            lblCounter.Text = @"0";
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBoxHelper.ShowWarningMessage("База была повреждена или удалена", this);
                    return;
                }
                catch (Exception)
                {
                    //ignore
                }
            }
            else
            {
                MessageBoxHelper.ShowWarningMessage("Ничего не найдено", this);
            }
        }

        #endregion

        #region Methods

        private void LoadAccountsInfo(IEnumerable<AccountEntity> accountEntities, ILifetimeScope scope)
        {
            var tempList = new List<ListViewItem>();

            var rateService = scope.Resolve<IRateService>();

            foreach (var account in accountEntities.Where(x => x.IsArchive == false))
            {
                var total = new AccountTotalPayments();
                var paymentDocuments = account.PaymentDocuments
                    .Where(x => x.PaymentDate.Date >= dateFrom.Value.Date && x.PaymentDate.Date <= dateTo.Value.Date);

                var paymentDocumentEntities = paymentDocuments;
                if (!paymentDocumentEntities.Any())
                    continue;

                var listViewItem = new ListViewItem(new[]
                {
                     account.Location.Street.StreetName, account.Location.HouseNumber,
                        account.Location.BuildingCorpus, account.Location.ApartmentNumber,
                    account.Account.ToString(),
                });

                listViewItem.SubItems.AddRange(Enumerable.Repeat("-", lvlMonthReport.Columns.Count - 1).ToArray());

                var accountsCount = GetAccountsCount(accountEntities, account.Location);

                foreach (var paymentDocumentEntity in paymentDocumentEntities)
                {
                    var rate = rateService.GetCurrentRate(accountsCount, account.Location, paymentDocumentEntity.PaymentDate);

                    var columnIndex = lvlMonthReport.Columns.IndexOfKey(GetColumnKey(paymentDocumentEntity.PaymentDate.Date));

                    if (columnIndex != -1)
                    {
                        listViewItem.SubItems[columnIndex].Text = $@"{ paymentDocumentEntity.Received.ToString(CultureInfo.CurrentCulture)}";

                        listViewItem.SubItems[columnIndex + 1].Text = rate.ToString(CultureInfo.CurrentCulture);
                    }
                }

                listViewItem.Tag = new DebtorModel() { Account = account, AccountsCount = accountsCount };
                tempList.Add(listViewItem);
            }

            if (tempList.Count == 0)
            {
                MessageBoxHelper.ShowWarningMessage("По данным критериям ничего не найдено", this);
                return;
            }

            lblCounter.Text = tempList.Count.ToString();
            lvlMonthReport.Items.AddRange(tempList.ToArray());
        }

        private int GetAccountsCount(IEnumerable<AccountEntity> accounts, LocationEntity searchLocation)
        {
            return accounts.Count(x =>
                x.Location.HouseNumber.Equals(searchLocation.HouseNumber, StringComparison.OrdinalIgnoreCase) &&
                x.Location.BuildingCorpus.Equals(searchLocation.BuildingCorpus, StringComparison.OrdinalIgnoreCase) &&
                x.Location.ApartmentNumber.Equals(searchLocation.ApartmentNumber, StringComparison.OrdinalIgnoreCase) &&
                x.IsDeleted == false
                && x.IsArchive == false);
        }

        private static AccountType Convert(int index)
        {
            if (index == 2)
                return AccountType.All;

            return index == 0 ? AccountType.Municipal : AccountType.Private;
        }

        private void CreateColumns(DateTime from, DateTime to)
        {
            lvlMonthReport.Clear();

            var columns = new List<ColumnHeader>();

            do
            {
                columns.Add(new ColumnHeader { Text = from.ToString("Y"), Tag = from.Month, Name = GetColumnKey(from) });
                columns.Add(new ColumnHeader() { Text = "Тариф" });
                if (from.Month == to.Month && from.Year == to.Year)
                {
                    break;
                }

                from = from.AddMonths(1);
            } while (true);


            lvlMonthReport.Columns.Add("Улица");
            lvlMonthReport.Columns.Add("Дом");
            lvlMonthReport.Columns.Add("Корпус");
            lvlMonthReport.Columns.Add("Квартира");
            lvlMonthReport.Columns.Add("Счет");
            lvlMonthReport.Columns.AddRange(columns.ToArray());
            lvlMonthReport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvlMonthReport.Columns[0].Width = 150;
            lvlMonthReport.Columns[4].Width = 100;
            lvlMonthReport.Columns[lvlMonthReport.Columns.Count - 1].Width = 50;
        }

        private static string GetColumnKey(DateTime @from)
        {
            return $"{from.Year}{from.Month}";
        }

        private static string ValidPersonalAccount(string personalAccount)
        {
            if (personalAccount.Length > PersonalAccountLength)
            {
                personalAccount = personalAccount.Substring(personalAccount.Length - PersonalAccountLength);
            }

            return personalAccount;
        }

        #endregion

        #region Data source

        private void cmbStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbHouses.DataSource = null;
            cmbBuildings.DataSource = null;
            cmbApartmens.DataSource = null;
        }

        private void cmbHouses_DropDown(object sender, EventArgs e)
        {
            _dataSourceHelper.StreetIndexChanged
                (cmbStreets, cmbHouses, x => x.HouseNumber);
        }

        private void cmbBuildings_DropDown(object sender, EventArgs e)
        {
            _dataSourceHelper.HouseIndexChanged
                (cmbStreets, cmbHouses, cmbBuildings, x => x.BuildingCorpus);
        }

        private void cmbApartments_DropDown(object sender, EventArgs e)
        {
            _dataSourceHelper.BuildingIndexChanged
                (cmbStreets, cmbHouses, cmbBuildings, cmbApartmens, x => x.ApartmentNumber);
        }

        private void cmbHouses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbHouses.SelectedIndex == 0)
                cmbApartmens.SelectedIndex = 0;

            _dataSourceHelper.HouseIndexChanged
                (cmbStreets, cmbHouses, cmbBuildings, x => x.BuildingCorpus);
        }

        #endregion

        #region ColumnHeader click

        private void lvlMonthReportTest_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvlMonthReport.Sorting = lvlMonthReport.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

            if (e.Column > 4)
            {
                lvlMonthReport.ListViewItemSorter = new ListViewStringComparer(e.Column, lvlMonthReport.Sorting);

                lvlMonthReport.Sort();
            }
        }

        #endregion

        #endregion

        #region RateListView

        #region buttons

        private void btnAddRate_Click_1(object sender, EventArgs e)
        {
            using (var rate = new RateItemForm())
            {
                var dialogResult = rate.ShowDialog(this);

                if (dialogResult == DialogResult.OK)
                {
                    LoadRates();
                }
            }
        }

        private void dtnRateForceDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBoxHelper.ShowConfirmMessage
                ("Вы уверены, что хотите безвозвратно удалить данные", this);

            if (confirm != DialogResult.Yes)
                return;

            foreach (ListViewItem lvlRatesItem in lvlRates.CheckedItems)
            {
                if (lvlRatesItem.Tag is RateEntity rate)
                {
                    try
                    {
                        using (var scope = _container.BeginLifetimeScope())
                        {
                            var service = scope.Resolve<IRateService>();
                            service.Delete(rate);
                        }

                        LoadRates();
                    }
                    catch (IOException)
                    {
                        MessageBoxHelper.ShowWarningMessage("Не удалось удалить", this);
                        return;
                    }
                }
            }
        }

        private void btnChangeRatesPrice_Click(object sender, EventArgs e)
        {
            using (var form = new RatePriceForm())
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                foreach (ListViewItem lvlRatesItem in lvlRates.CheckedItems)
                {
                    if (!(lvlRatesItem.Tag is RateEntity rate))
                        continue;

                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var service = scope.Resolve<IRateService>();
                        var result = service.ChangeRatePrice(rate, form.Price, form.DateTo);
                        if (result != null)
                        {
                            lvlRatesItem.Tag = result;
                        }
                    }
                }

                LoadRates();
            }
        }

        private void btnSendRateToArchive_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvlRatesCheckedItem in lvlRates.CheckedItems)
            {
                if (lvlRatesCheckedItem.Tag is RateEntity rate)
                {
                    rate.EndDate = DateTime.Now;
                    rate.IsArchive = true;
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var rateService = scope.Resolve<IRateService>();
                        var currentRate = rateService.GetItemById(rate.Id);
                        if (currentRate != null)
                        {
                            currentRate.IsArchive = true;
                            currentRate.EndDate = DateTime.Now;
                            rateService.Update(currentRate);
                        }
                    }
                }
            }

            LoadRates();
        }

        private void btnDeleteDiscounts_Click(object sender, EventArgs e)
        {
            var confirm =
                MessageBoxHelper.ShowConfirmMessage("Вы уверены, что хотите безвозвратно удалить данные?", this);
            if (confirm != DialogResult.Yes)
                return;

            foreach (ListViewItem listViewItem in lvlDiscounts.CheckedItems)
            {
                if (!(listViewItem.Tag is DiscountEntity discount))
                    continue;

                using (var scope = _container.BeginLifetimeScope())
                {
                    var discountService = scope.Resolve<IDiscountDocumentService>();
                    var result = discountService.GetItems(x => x.AccountId == discount.AccountId).ToList();
                    foreach (var discountEntity in result)
                    {
                        discountService.Delete(discountEntity);
                    }
                }
            }

            LoadDiscounts();
        }

        private void btnRateArchive_Click(object sender, EventArgs e)
        {
            cntRateArchive.Show(btnRateArchive, 0, btnRateArchive.Height);
        }

        private void btnShowArchiveRates_Click(object sender, EventArgs e)
        {
            LoadRates(false);
        }

        private void btnHideArchiveRates_Click(object sender, EventArgs e)
        {
            LoadRates();
        }

        #endregion

        #region Right click

        private void lvlRates_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cntRates.Show();
        }

        #endregion

        #endregion

        #region DiscountListView

        #region Buttons

        private void btnDiscountOnAddress_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountOnAddressForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDiscounts();
                    MessageBoxHelper.ShowCompeteMessage("Добавлено", this);
                }
            }
        }

        private void btnDiscountOnAccount_Click_1(object sender, EventArgs e)
        {
            using (var form = new DiscountAccountItemForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDiscounts();
                }
            }
        }

        private void btnAddDiscountPercent_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountPercentItem())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBoxHelper.ShowCompeteMessage("Успешно", this);
                }
            }
        }

        private void btnAddDiscountDescription_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountDescriptionItem())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBoxHelper.ShowCompeteMessage("Успешно", this);
                }
            }
        }

        private void btnShowArchiveDiscount_Click(object sender, EventArgs e)
        {
            LoadDiscounts(false);
        }

        private void btnHideArchiveDiscount_Click(object sender, EventArgs e)
        {
            LoadDiscounts();
        }

        private void btnDiscountPercentAndDescription_Click(object sender, EventArgs e)
        {
            cntPercentAndDescription.Show(btnDiscountPercentAndDescription, 0, btnDiscountPercentAndDescription.Height);
        }

        private void btnSendDiscountToArchive_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvlDiscountsItem in lvlDiscounts.CheckedItems)
            {
                if (lvlDiscountsItem.Tag is DiscountEntity discount)
                {
                    try
                    {
                        using (var scope = _container.BeginLifetimeScope())
                        {
                            var discountService = scope.Resolve<IDiscountDocumentService>();
                            discountService.SendToArchive(discount);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBoxHelper.ShowWarningMessage("Ошибка операции", this);
                        return;
                    }

                    LoadDiscounts();
                }
            }
        }


        #endregion

        #region ToolStrip

        private void btnDiscountsArchive_Click(object sender, EventArgs e)
        {
            cntDiscountArchive.Show(btnDiscountsArchive, 0, btnDiscountsArchive.Height);
        }

        #endregion

        #region RightClick

        private void lvlDiscountsTest_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cntDiscounts.Show();
        }

        #endregion

        #endregion

        #region TotalReportListView

        private void btnCreateTotalReport_Click(object sender, EventArgs e)
        {
            if (!(cmbTotalReportStreets.SelectedValue is int streetId))
            {
                MessageBoxHelper.ShowWarningMessage("Выберите улицу", this);
                return;
            }

            if (dateTotalReportFrom.Value.Date > dateTotalReportTo.Value.Date)
            {
                MessageBoxHelper.ShowWarningMessage("Начальная дата не может быть больше", this);
                return;
            }

            lvlTotalReport.Items.Clear();

            using (var scope = _container.BeginLifetimeScope())
            {
                var calculateService = scope.Resolve<ICalculationService>();
                var addresses =
                    calculateService.CalculateIncomeWithParameters(streetId, cmbTotalReportHouses.SelectedIndex == 0 ? string.Empty : cmbTotalReportHouses.Text,
                        cmbTotalReportBuilding.SelectedIndex == 0 ? string.Empty : cmbTotalReportBuilding.Text,
                        dateTotalReportFrom.Value, dateTotalReportTo.Value);
                CreateReport(addresses);
            }

        }

        private void btnTotalReport_Click(object sender, EventArgs e)
        {
            if (dateTotalReportFrom.Value.Date > dateTotalReportTo.Value.Date)
            {
                MessageBoxHelper.ShowWarningMessage("Начальная дата не может быть больше", this);
                return;
            }

            lvlTotalReport.Items.Clear();

            using (var scope = _container.BeginLifetimeScope())
            {
                var calculateService = scope.Resolve<ICalculationService>();
                var addresses =
                    calculateService.CalculateIncome(dateTotalReportFrom.Value.Date, dateTotalReportTo.Value.Date);
                CreateReport(addresses);
            }
        }

        private void CreateReport(IReadOnlyCollection<Address> incomeReport)
        {
            if (incomeReport != null && incomeReport.Count != 0)
            {
                var listViewItems = new List<ListViewItem>();

                foreach (var payments in incomeReport)
                {
                    foreach (var houses in payments.Houses)
                    {
                        foreach (var building in houses.Buildings.OrderBy(x => x.BuildingNumber))
                        {
                            var item = new ListViewItem(new[]
                            {
                                    payments.StreetName,
                                    houses.HouseNumber,
                                    building.BuildingNumber,
                                    building.AccruedMunicipal.ToString(CultureInfo.CurrentCulture),
                                    building.AccruedPrivate.ToString(CultureInfo.CurrentCulture),
                                    building.ReceivedMunicipal.ToString(CultureInfo.CurrentCulture),
                                    building.ReceivedPrivate.ToString(CultureInfo.CurrentCulture),
                                    building.TotalReceived.ToString(CultureInfo.CurrentCulture),
                                    building.TotalAccrued.ToString(CultureInfo.CurrentCulture),
                                    $"{building.Percent.ToString(CultureInfo.CurrentCulture)}%"
                                });
                            listViewItems.Add(item);
                        }
                    }
                }

                lvlTotalReport.Items.AddRange(listViewItems.ToArray());
            }
            else
            {
                MessageBoxHelper.ShowWarningMessage("Платежей не найдено", this);
                return;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (lvlTotalReport.Items.Count == 0)
            {
                MessageBoxHelper.ShowWarningMessage("Сначала сформируйте отчте", this);
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = @"Excel files(*.xlsx)|*xlsx";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        ExportService.ExportTotalReportToExcel(lvlTotalReport, saveFileDialog.FileName);
                        MessageBoxHelper.ShowCompeteMessage("Успешно", this);
                    }

                    catch (FileNotFoundException)
                    {
                        MessageBoxHelper.ShowWarningMessage("Файл не найден", this);
                    }

                    catch (IOException)
                    {
                        MessageBoxHelper.ShowWarningMessage("Файл уже открыт, или нет доступа для записи", this);
                    }

                    catch (ArgumentNullException)
                    {
                        MessageBoxHelper.ShowWarningMessage("Файл поврежден", this);
                    }
                }
            }
        }

        private void cmbTotalReportStreets_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _dataSourceHelper.StreetIndexChanged(cmbTotalReportStreets, cmbTotalReportHouses, x => x.HouseNumber);
            cmbTotalReportBuilding.DataSource = null;
        }

        private void cmbTotalReportHouses_DropDown(object sender, EventArgs e)
        {
            _dataSourceHelper.StreetIndexChanged
                (cmbTotalReportStreets, cmbTotalReportHouses, x => x.HouseNumber);
        }

        private void cmbTotalReportHouses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _dataSourceHelper.HouseIndexChanged
                (cmbTotalReportStreets, cmbTotalReportHouses, cmbTotalReportBuilding, x => x.BuildingCorpus);
        }

        #endregion

        #region BackgroundWorker

        private void backgroundWorker1_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var importReport = new ImportReportModel();

            if (e.Argument.ToString() is string options)
            {
                foreach (var file in _files)
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var service = scope.ResolveNamed<IDataLoader>(options);
                        try
                        {
                            var report = service.LoadData(file);
                            importReport.Add += report.Add;
                            importReport.Updates += report.Updates;
                            importReport.CorruptedRecords += report.CorruptedRecords;

                        }
                        catch (FileLoadException)
                        {
                            MessageBoxHelper.ShowWarningMessage("Не удалось загрузить данные из файла", this);
                            return;
                        }
                        catch (SqlException)
                        {
                            MessageBoxHelper.ShowWarningMessage("Программа не может сохранить файл по выбранному пути",
                                this);
                            return;
                        }
                        catch (IOException exsException)
                        {
                            MessageBoxHelper.ShowWarningMessage(exsException.Message, this);
                            return;
                        }
                        catch (NullReferenceException)
                        {
                            MessageBoxHelper.ShowWarningMessage("Файл пуст или поврежден", this);
                            return;
                        }
                    }
                    FileManager.DeleteTempFolder();
                }

                MessageBoxHelper.ShowCompeteMessage(
                    $"Успешно загружено. Добавленно {importReport.Add}\n Обновленно {importReport.Updates}",
                    this);

                if (importReport.CorruptedRecords > 0)
                {
                    MessageBoxHelper.ShowWarningMessage(
                        "Были найдены записи, которые не удалось сопоставить. Записи сохранены в папке: Не сопоставленные записи",
                        this);
                    return;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender,
            System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _form.Close();
        }

        #endregion

        #region Help button

        private void btnClear_Click(object sender, EventArgs e)
        {
            chkIsArchive.Checked = false;
            chkIsBuilding.Checked = false;
            cmbHouses.Text = string.Empty;
            cmbBuildings.Text = string.Empty;
            cmbApartmens.Text = string.Empty;
            txtAccount.Text = string.Empty;
            try
            {
                cmbStreets.SelectedIndex = 0;
            }
            catch (Exception)
            {
                //
            }
            cmbHouses.DataSource = null;
            cmbBuildings.DataSource = null;
            cmbApartmens.DataSource = null;
        }

        private static void ResetColors(ListView listView)
        {
            foreach (ListViewItem listViewItem in listView.Items)
            {
                listViewItem.BackColor = Color.White;
            }
        }

        private void lvlMonthReportTest_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvlMonthReport.FocusedItem.Tag is DebtorModel account)
                {
                    using (var form = new AccountDetailsForm())
                    {
                        form.AccountDetailsModel = new AccountDetailsModel
                        {
                            Account = account.Account.Account.ToString(),
                            Street = cmbStreets.Text,
                            House = account.Account.Location.HouseNumber,
                            Building = account.Account.Location.BuildingCorpus,
                            Apartment = account.Account.Location.ApartmentNumber,
                            Accrued = account.Account.PaymentDocuments.FirstOrDefault()?.Accrued
                                .ToString(CultureInfo.CurrentCulture),
                            Received = account.Account.PaymentDocuments.FirstOrDefault()?.Received
                                .ToString(CultureInfo.CurrentCulture),
                            AccountType = account.Account.AccountType == AccountType.Private ? "Частный" : "Муниципальный"
                        };
                        form.ShowDialog(this);
                    }
                }
            }
            catch (ObjectDisposedException)
            {

            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F3 when btnDataBase.Visible == false:
                    btnDataBase.Visible = true;
                    return;
                case Keys.F3 when btnDataBase.Visible:
                    btnDataBase.Visible = false;
                    break;
            }
        }


        #endregion

        private void btnCreateTotalReportAll_Click(object sender, EventArgs e)
        {
            if (dateTotalReportAllFrom.Value.Date > dateTotalReportAllTo.Value.Date)
            {
                MessageBoxHelper.ShowWarningMessage("Начальная дата не может быть больше", this);
                return;
            }

            lvlTotalReportAll.Items.Clear();

            using (var scope = _container.BeginLifetimeScope())
            {
                var calculateService = scope.Resolve<ICalculationService>();
                var result =
                    calculateService.CalculateTotalIncome(dateTotalReportAllFrom.Value.Date, dateTotalReportAllTo.Value.Date);

                if (result != null)
                {
                    var item = new ListViewItem(new[]
                    {
                        result.AccruedMunicipal.ToString(CultureInfo.CurrentCulture),
                        result.AccruedPrivate.ToString(CultureInfo.CurrentCulture),
                        result.ReceivedMunicipal.ToString(CultureInfo.CurrentCulture),
                        result.ReceivedPrivate.ToString(CultureInfo.CurrentCulture),
                        result.TotalReceived.ToString(CultureInfo.CurrentCulture),
                        result.TotalAccrued.ToString(CultureInfo.CurrentCulture),
                        $"{result.Percent.ToString(CultureInfo.CurrentCulture)}%"
                    });

                    lvlTotalReportAll.Items.Add(item);
                }
                else
                {
                    MessageBoxHelper.ShowWarningMessage("Платежей не найдено", this);
                    return;
                }
            }
        }

        private void btnTotalReportAllClear_Click(object sender, EventArgs e)
        {
            lvlTotalReportAll.Items.Clear();
        }

        private void btnTotalReportExport_Click(object sender, EventArgs e)
        {
            if (lvlTotalReportAll.Items.Count == 0)
            {
                MessageBoxHelper.ShowWarningMessage("сначала сформируйте отчет", this);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = @"Excel files(*.xlsx)|*xlsx";
                dialog.AddExtension = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ExportService.ExportTotalReportAllForExcel(lvlTotalReportAll, dialog.FileName);
                    MessageBoxHelper.ShowCompeteMessage("Успешно", this);
                }
            }
        }
    }
}
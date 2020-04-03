using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.Data.Services.EntityService.Rate;
using BookKeeper.Data.Services.Export;
using BookKeeper.Data.Services.Load;
using BookKeeper.UI.Helpers;
using BookKeeper.UI.Models.Account;
using BookKeeper.UI.Models.Discount;
using BookKeeper.UI.Models.Rate;
using BookKeeper.UI.UI.Forms;
using BookKeeper.UI.UI.Forms.Account;
using BookKeeper.UI.UI.Forms.Discount;
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

namespace BookKeeper.UI
{
    public partial class MainForm : MetroForm
    {
        #region Initialize

        private readonly Autofac.IContainer _container;
        private ProgressForm _form;
        private string[] _files;
        private const int PersonalAccountLength = 8;
        private string _addressTemplate = "{0} Дом: {1} Корпус: {2} Квартира: {3}";

        public MainForm()
        {
            InitializeComponent();
            dateFrom.ShowUpDown = true;
            _container = AutofacConfiguration.ConfigureContainer();
            try
            {

                using (var scope = _container.BeginLifetimeScope())
                {
                    var rateService = scope.Resolve<IRateService>();
                    var rates = rateService.GetItem(x => x.IsDefault);
                    if (rates == null || rates.Price != System.Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]))
                    {
                        rateService.Add(new RateEntity()
                        {
                            Price = System.Convert.ToDecimal(ConfigurationManager.AppSettings["DefaultPrice"]),
                            StartDate = DateTime.MinValue,
                            EndDate = DateTime.MaxValue,
                            IsDefault = true,
                        });
                    }
                }
            }
            catch (FormatException)
            {
                MessageBoxHelper.ShowWarningMessage("Конфигурационный файл был поврежден, исправте его", this);
                return;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAddresses();
            LoadRates();
            LoadDiscounts();
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
            cntDatabase.Show(btnDataBase, 0, btnDataBase.Height); ;
        }
        private void btnAddDiscounts_Click(object sender, EventArgs e)
        {
            cntDiscounts.Show(btnAddDiscounts, 0, btnAddDiscounts.Height);
        }

        private void btnRates_Click(object sender, EventArgs e)
        {
            cntRates.Show(btnRates, 0, btnRates.Height);
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

        private void btnShowDebtor_Click(object sender, EventArgs e)
        {
            ResetColors(lvlMonthReportTest);
            foreach (ListViewItem listViewItem in lvlMonthReportTest.Items)
            {
                try
                {
                    decimal totalPayments = 0;
                    if (!(listViewItem.Tag is AccountEntity account))
                        continue;

                    foreach (var payment in account.PaymentDocuments)
                    {
                        using (var scope = _container.BeginLifetimeScope())
                        {
                            var calculateService = scope.Resolve<ICalculationService>();
                            var result = calculateService.CalculatePrice(account.Id, account.Location,
                                payment.Received, payment.PaymentDate);

                            totalPayments += result;
                        }
                    }

                    if (totalPayments < 0)
                    {
                        listViewItem.UseItemStyleForSubItems = false;
                        listViewItem.SubItems[0].BackColor = Color.LightCoral;
                    }

                    totalPayments = 0;
                }
                catch (NullReferenceException )
                {
                    MessageBoxHelper.ShowWarningMessage("Тариф по умолчанию был удален, дальнейшие рачеты невозможны. Перезапустите программу",this);
                    return;
                }
            }
        }

        #region BackUp

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var backupService = scope.Resolve<IBackupService>();

                        var backupFileName = backupService.CreateBackup(dialog.SelectedPath);

                        MessageBoxHelper.ShowCompeteMessage($"Бэкап создан {Path.Combine(dialog.SelectedPath, backupFileName)}", this);
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
                catch (SqlException)
                {
                    MessageBoxHelper.ShowWarningMessage("Не удалось восстановить", this);
                }
            }
        }

        #endregion

        private void btnHouses_Click(object sender, EventArgs e)
        {
            using (var form = new HousesForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBoxHelper.ShowCompeteMessage("Добавлено", this);
                }
            }
        }

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
        #endregion

        #region MonthReportListView

        #region Buttons

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cmbStreet.SelectedValue is int streetId)
            {
                var searchModel = new SearchModel
                {
                    StreetId = streetId,
                    Account = ValidPersonalAccount(txtAccount.Text),
                    AccountType = Convert(cmbPersonalAccountType.SelectedIndex),
                    HouseNumber = txtHouse.Text,
                    BuildingNumber = txtBuilding.Text,
                    ApartmentNumber = txtApartment.Text,
                    IsArchive = metroCheckBox1.Checked,
                    From = dateFrom.Value,
                    To = dateTo.Value
                };

                CreateColumns(dateFrom.Value.Date, dateTo.Value.Date);

                try
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var service = scope.Resolve<ISearchService>();
                        var searchResult = service.FindAccounts(searchModel);

                        if (searchResult != null && searchResult.Any())
                        {
                            if (backgroundWorker2.IsBusy == false)
                            {
                                backgroundWorker2.RunWorkerAsync(searchResult);
                                LoadAccountsInfo(searchResult);
                            }
                        }
                        else
                        {
                            MessageBoxHelper.ShowWarningMessage("Ничего не найдено", this);
                            lblCounter.Text = "0";
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBoxHelper.ShowWarningMessage("База была повреждена или удалена", this);
                    return;
                }
            }
            else
            {
                MessageBoxHelper.ShowWarningMessage("Ничего не найдено", this);
            }
        }
        private void lvlMonthReport_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvlMonthReportTest.FocusedItem.Tag is AccountEntity account)
                {
                    using (var form = new AccountDetailsForm())
                    {
                        form.AccountDetailsModel = new AccountDetailsModel
                        {
                            Account = account.Account.ToString(),
                            Street = cmbStreet.Text,
                            House = account.Location.HouseNumber,
                            Building = account.Location.BuildingCorpus,
                            Apartment = account.Location.ApartmentNumber,
                            Accrued = account.PaymentDocuments.FirstOrDefault()?.Accrued.ToString(CultureInfo.CurrentCulture),
                            Received = account.PaymentDocuments.FirstOrDefault()?.Received.ToString(CultureInfo.CurrentCulture),
                        };
                        form.ShowDialog(this);
                    }
                }
            }
            catch (ObjectDisposedException)
            {

            }
        }

        #endregion

        #region Methods

        private void LoadAccountsInfo(IEnumerable<AccountEntity> accountEntities)
        {
            var tempList = new List<ListViewItem>();

            foreach (var account in accountEntities.ToList())
            {
                var paymentDocuments = account.PaymentDocuments
                    .Where(x => x.PaymentDate.Date >= dateFrom.Value.Date && x.PaymentDate.Date <= dateTo.Value.Date);


                if (!paymentDocuments.Any())
                    continue;


                var listViewItem = new ListViewItem(new string[]
                {
                    account.Account.ToString(),
                });

                listViewItem.SubItems.AddRange(Enumerable.Repeat("-", lvlMonthReportTest.Columns.Count - 1).ToArray());

                foreach (var paymentDocumentEntity in paymentDocuments)
                {
                    var columnIndex = lvlMonthReportTest.Columns.IndexOfKey(GetColumnKey(paymentDocumentEntity.PaymentDate));
                    if (columnIndex != -1)
                        listViewItem.SubItems[columnIndex].Text = paymentDocumentEntity.Received.ToString(CultureInfo.CurrentCulture);

                }

                listViewItem.Tag = account;
                tempList.Add(listViewItem);
            }

            if (tempList.Count == 0)
            {
                MessageBoxHelper.ShowWarningMessage("По данным критериям ничего не найдено", this);
                return;
            }

            lblCounter.Text = tempList.Count.ToString();
            lvlMonthReportTest.Items.AddRange(tempList.ToArray());
        }

        private static AccountType Convert(int index)
        {
            return index == 0 ? AccountType.Municipal : AccountType.Private;
        }

        private void CreateColumns(DateTime from, DateTime to)
        {
            lvlMonthReportTest.Clear();

            var columns = new List<ColumnHeader>();

            do
            {
                columns.Add(new ColumnHeader { Text = from.ToString("Y"), Tag = from.Month, Name = GetColumnKey(from) });
                if (from.Month == to.Month && from.Year == to.Year)
                {
                    break;
                }

                from = from.AddMonths(1);
            } while (true);

            lvlMonthReportTest.Columns.Add("Счет");
            lvlMonthReportTest.Columns.AddRange(columns.ToArray());
            lvlMonthReportTest.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvlMonthReportTest.Columns[0].Width = 150;
        }

        private string GetColumnKey(DateTime @from)
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

        private void btnDeleteRate_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvlRates.CheckedItems)
            {
                DeleteItems(item);
            }
        }

        #endregion

        #region  Method

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
            { Tag = model.RateDocument };

            lvlRates.Items.Add(listViewItem);
        }

        private void DeleteItems(ListViewItem item)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IRateService>();

                if (!(item.Tag is RateEntity rate))
                    return;

                var document = service.GetItemById(rate.Id);
                if (document == null)
                    return;

                document.EndDate = DateTime.Now;
                document.IsArchive = true;
                service.Update(document);

                lvlRates.Items.Remove(item);
            }
        }

        private void btnShowDeleteRates_Click(object sender, EventArgs e)
        {
            LoadRates(false);
        }

        private void bthHideDeletedRates_Click(object sender, EventArgs e)
        {
            LoadRates();
        }
        private void lvlRates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvlRates.FocusedItem.Tag is RateEntity rate)
            {
                using (var form = new RateItemForm())
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var service = scope.Resolve<ILocationService>();
                        var locations = service.GetItem(x => x.Id == rate.Id);
                        form.RateModel = new RateModel
                        {
                            House = locations.HouseNumber,
                            Building = locations.BuildingCorpus,
                            Price = rate.Price.ToString(CultureInfo.CurrentCulture),
                            Start = rate.StartDate,
                            End = rate.EndDate
                        };
                        form.ShowDialog();
                    }
                }
            }
        }
        #endregion


        #endregion

        #region DiscountListView

        #region Buttons

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

        private void dtnDiscountDescription_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountDescriptionItem())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBoxHelper.ShowCompeteMessage("Успешно", this);
                }
            }
        }


        #endregion

        #region Methods

        private void LoadDiscount(DiscountModel model)
        {
            if (model == null)
                return;

            switch (model.Type)
            {
                case DiscountType.PersonalAccount:
                    {
                        var listViewItem = new ListViewItem(new[]
                            {
                            "Счет", model.Account, $"{model.Price}%", model.Description
                        })
                        { Tag = model };
                        lvlDiscounts.Items.Add(listViewItem);
                        break;
                    }
                case DiscountType.Address:
                    {
                        var listViewItem = new ListViewItem(new[]
                            {
                            "Адрес", model.Address
                            , $"{model.Price}%", model.Description
                        })
                        { Tag = model };
                        lvlDiscounts.Items.Add(listViewItem);
                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        #endregion

        #endregion

        #region BackgroundWorker

        private void backgroundWorker1_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
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

                            MessageBoxHelper.ShowCompeteMessage(
                                $"Успешно загружено. Добавленно {report.Add} \n Обновленно {report.Updates} \n Поврежденых записей {report.CorruptedRecords}",
                                this);
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
                        catch (IOException)
                        {
                            MessageBoxHelper.ShowWarningMessage("Закройте саначала файл", this);
                            return;
                        }
                        catch (NullReferenceException)
                        {
                            MessageBoxHelper.ShowWarningMessage("Файл пуст или поврежден", this);
                            return;
                        }
                    }
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _form.Close();
        }

        #endregion

        #region Load Items on Start

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
                MessageBoxHelper.ShowWarningMessage("Не удалось загрузить адреса", this);
            }
        }

        private void LoadRates(bool deleted = true)
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
                    if (rate.IsArchive && deleted)
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
                                rate.Description
                            })
                        { Tag = rate };

                        lvlRates.Items.Add(listView);
                    }
                }
            }
        }

        private void LoadDiscounts(bool dontShowArchive = true)
        {
            lvlDiscountsTest.Items.Clear();
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
                    foreach (var discount in discounts)
                    {
                        if (discount.IsArchive && dontShowArchive)
                            continue;

                        if (discount.IsDeleted)
                            continue;

                        var firstColumnContentType =
                            discount.Type == DiscountType.PersonalAccount ? "Счет" : "Адрес";
                        var secondColumnContentType =
                            discount.Type == DiscountType.PersonalAccount
                                ? discount.Account.Account.ToString(CultureInfo.CurrentCulture)
                                : string.Format(_addressTemplate, discount.Account.Location.Street.StreetName,
                                    discount.Account.Location.HouseNumber, discount.Account.Location.BuildingCorpus,
                                    discount.Account.Location.ApartmentNumber);

                        var listView = new ListViewItem(new[]
                        {
                            firstColumnContentType, secondColumnContentType,
                            discount.Percent.ToString(CultureInfo.CurrentCulture)+"%", discount.Description
                        })
                        {
                            Tag = discount
                        };
                        if (discount.IsArchive)
                        {
                            listView.SubItems[0].BackColor = Color.LightSlateGray;
                        }

                        list.Add(listView);
                    }
                    lvlDiscountsTest.Items.AddRange(list.ToArray());
                }
            }
        }

        #endregion

        #region Filter buttons

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHouse.Text = string.Empty;
            txtBuilding.Text = string.Empty;
            txtApartment.Text = string.Empty;
            txtAccount.Text = string.Empty;
        }

        #endregion

        private void btnCreateTotalReport_Click(object sender, EventArgs e)
        {
            lvlTotalReport.Items.Clear();
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ICalculationService>();
                var result = service.CalculateAllPrice(dateFrom.Value, dateTo.Value);
                if (result != null)
                {
                    lvlTotalReport.Items
                        .AddRange(result
                            .Select(payments =>
                                new ListViewItem(new[]
                                    {payments.StreetName,
                                        payments.AccruedMunicipal.ToString(CultureInfo.CurrentCulture),
                                        payments.AccruedPrivate.ToString(CultureInfo.CurrentCulture),
                                        payments.ReceivedMunicipal.ToString(CultureInfo.CurrentCulture),
                                        payments.ReceivedPrivate.ToString(CultureInfo.CurrentCulture),
                                        payments.TotalReceived.ToString(CultureInfo.CurrentCulture),
                                        payments.TotalAccrued.ToString(CultureInfo.CurrentCulture),
                                        payments.Percent.ToString(CultureInfo.CurrentCulture)
                                    }))
                            .ToArray());
                }
            }
        }

        /// <summary>
        /// Только для удобства в разработке, в релизе этого не должно быть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#if DEBUG
        private void dtnRateForceDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvlRatesItem in lvlRates.CheckedItems)
            {
                if (lvlRatesItem.Tag is RateEntity rate)
                {
                    try
                    {
                        using (var scope = _container.BeginLifetimeScope())
                        {
                            var service = scope.Resolve<IRateService>();
                            var result = service.GetItemById(rate.Id);
                            if (result != null)
                            {
                                result.IsDeleted = true;
                                service.Update(result);
                            }
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
#endif

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (lvlTotalReport.Items.Count == 0)
            {
                MessageBoxHelper.ShowWarningMessage("Сначала сформируйте отчте", this);
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = @"Excel files(*.xls;*.xls)|*.xlsx;*xlsx|All files(*.*)|*.*";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        ExportService.ExportTotalReportToExcel(lvlTotalReport, saveFileDialog.FileName);
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
                        var result = service.ChangeRatePrice(rate, form.Price);
                        if (result != null)
                        {
                            lvlRatesItem.Tag = result;
                        }
                    }
                }
                LoadRates();
            }
        }

        private void btnSendDiscountToArchive_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvlDiscountsItem in lvlDiscountsTest.CheckedItems)
            {
                if (lvlDiscountsItem.Tag is DiscountDocumentEntity discount)
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

        private void btnHideArchiveDiscounts_Click(object sender, EventArgs e)
        {
            LoadDiscounts();
        }

        private void btnShowArchiveDiscounts_Click(object sender, EventArgs e)
        {
            LoadDiscounts(false);
        }

        private void btnHideDebtor_Click(object sender, EventArgs e)
        {
            ResetColors(lvlMonthReportTest);
        }

        private static void ResetColors(ListView listView)
        {
            foreach (ListViewItem listViewItem in listView.Items)
            {
                listViewItem.BackColor = Color.Empty;
            }
        }

        private void btnDeleteRates_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Вы действительно хотите безвозвратно удалить выбранные льготы?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.OK)
                return;

            foreach (ListViewItem listViewItem in lvlDiscountsTest.CheckedItems)
            {
                if (!(listViewItem.Tag is DiscountDocumentEntity discount))
                    continue;

                using (var scope = _container.BeginLifetimeScope())
                {
                    var discountService = scope.Resolve<IDiscountDocumentService>();
                    var result = discountService.GetItemById(discount.Id);
                    if (result != null)
                        discountService.Delete(result);
                }
            }
            LoadDiscounts();
        }
    }
}
using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Data.Entities.Rates;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Rate;
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
using System.Data.Entity.Core;
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

        public MainForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();

            lvlMonthReport.UseCustomBackColor = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAddresses();
            LoadRates();
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
            foreach (ListViewItem listViewItem in lvlMonthReport.Items)
            {

                if (listViewItem.Tag is AccountEntity account)
                {
                    foreach (var payment in account.PaymentDocuments)
                    {
                        RateDocumentEntity rate;
                        using (var scope = _container.BeginLifetimeScope())
                        {
                            var service = scope.Resolve<IRateDocumentService>();
                            rate = service.GetItem(x => x.LocationId == account.LocationId && x.EndDate.Month < dateTo.Value.Month);

                        }

                        decimal payments;

                        if (rate == null)
                            payments = payment.Received;

                        else
                        {
                            payments = payment.Received > rate.Price ? rate.Price : payment.Received;
                        }

                        if ((payments - payment.Accrued) >= 0)
                            continue;

                        listViewItem.UseItemStyleForSubItems = true;
                        listViewItem.SubItems[0].BackColor = Color.Red;
                    }
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
                //catch (SqlException)
                //{
                //    MessageBoxHelper.ShowWarningMessage("Не удалось восстановить", this);
                //}
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
                    LoadDiscount(form.DiscountModel);
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
                    LoadDiscount(form.DiscountModel);
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
                    IsArchive = metroCheckBox1.Checked
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
                            LoadAccountsInfo(searchResult);
                        }
                        else
                        {
                            MessageBoxHelper.ShowWarningMessage("Ничего не найдено",this);
                            lblCounter.Text = "0";
                        }
                    }
                }
                catch (EntityException)
                {
                    MessageBoxHelper.ShowWarningMessage("База была повреждена или удалена",this);
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
            if (lvlMonthReport.FocusedItem.Tag is AccountEntity account)
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
                    form.ShowDialog();
                }
            }
        }

        #endregion

        #region Methods

        private void LoadAccountsInfo(IEnumerable<AccountEntity> accountEntities)
        {
            var tempList = new List<ListViewItem>();

            foreach (var account in accountEntities)
            {
                var paymentDocuments = account.PaymentDocuments
                    .Where(x => x.PaymentDate.Month >= dateFrom.Value.Date.Month && x.PaymentDate.Month <= dateTo.Value.Date.Month && 
                                x.PaymentDate.Year >= dateFrom.Value.Date.Year && x.PaymentDate.Year <=dateTo.Value.Date.Year);

                if (!paymentDocuments.Any())
                    continue;

                tempList.AddRange(paymentDocuments
                    .Select(documentEntity =>
                        new ListViewItem(new[] {account.Account.ToString(),
                            documentEntity.Received.ToString(CultureInfo.CurrentCulture)})
                        { Tag = account }));
            }

            if (tempList.Count == 0)
            {
                MessageBoxHelper.ShowWarningMessage("По данным критериям ничего не найдено", this);
                return;
            }

            lblCounter.Text = tempList.Count.ToString();
            lvlMonthReport.Items.AddRange(tempList.ToArray());
        }

        private static AccountType Convert(int index)
        {
            return index == 0 ? AccountType.Municipal : AccountType.Private;
        }

        private void CreateColumns(DateTime from, DateTime to)
        {
            lvlMonthReport.Clear();

            var columns = new List<ColumnHeader>();

            do
            {
                columns.Add(new ColumnHeader { Text = from.ToString("Y") });
                if (from.Month == to.Month)
                {
                    break;
                }

                from = from.AddMonths(1);
            } while (true);

            lvlMonthReport.Columns.Add("Счет");
            lvlMonthReport.Columns.AddRange(columns.ToArray());
            lvlMonthReport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvlMonthReport.Columns[0].Width = 150;
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
                    LoadItem(rate.RateModel);
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
                var service = scope.Resolve<IRateDocumentService>();

                if (!(item.Tag is RateDocumentEntity rate))
                    return;

                var document = service.GetItemById(rate.Id);
                if (document == null)
                    return;

                document.EndDate = DateTime.Now;
                document.IsDeleted = true;
                service.Update(document);

                lvlRates.Items.Remove(item);
            }
        }

        private void btnShowDeleteRates_Click(object sender, EventArgs e)
        {
            if (chkDeletedRates.Checked)
                LoadRates();
        }

        private void bthHideDeletedRates_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvlRatesItem in lvlRates.Items)
            {
                if (lvlRatesItem.Tag is RateDocumentEntity rate)
                {
                    if (rate.EndDate < DateTime.Now)
                        lvlRatesItem.Remove();
                }
            }
        }
        private void lvlRates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvlRates.FocusedItem.Tag is RateDocumentEntity rate)
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
                            Description = rate.RatesDescription.FirstOrDefault()?.Description,
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

                            MessageBoxHelper.ShowCompeteMessage($"Успешно загружено. Добавленно {report.Add} \n Обновленно {report.Updates} \n Поврежденых записей {report.CorruptedRecords}", this);
                        }
                        catch (FileLoadException)
                        {
                            MessageBoxHelper.ShowWarningMessage("Не удалось загрузить данные из файла", this);
                            return;
                        }
                        catch (SqlException)
                        {
                            MessageBoxHelper.ShowWarningMessage("Программа не может сохранить файл по выбранному пути", this);
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

        private void LoadRates()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var documentService = scope.Resolve<IRateDocumentService>();
                var locationService = scope.Resolve<ILocationService>();

                var rates = documentService.GetWithInclude(x => x.RatesDescription);
                if (rates == null)
                    return;

                foreach (var rate in rates)
                {
                    if (rate.IsDeleted && chkDeletedRates.Checked == false)
                        continue;

                    foreach (var descriptionEntity in rate.RatesDescription)
                    {
                        var location = locationService.GetItem(x => x.Id == rate.LocationId);
                        if (location == null)
                            continue;

                        var listView = new ListViewItem(new[]
                            {
                                location.Street.StreetName,
                                location.HouseNumber,
                                location.BuildingCorpus,
                                rate.Price.ToString(CultureInfo.CurrentCulture),
                                descriptionEntity.Description
                            })
                        { Tag = rate };

                        lvlRates.Items.Add(listView);
                    }
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
        }

        #endregion
    }
}
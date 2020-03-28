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
using BookKeeper.Data.Services.Load;
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
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BookKeeper.UI
{
    public partial class MainForm : MetroForm
    {
        #region Initialize

        private readonly Autofac.IContainer _container;
        private ProgressForm _form;
        private string[] _files;

        public MainForm()
        {

            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAddresses();
            LoadRates(1);
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
            _form = new ProgressForm();
            _form.ShowDialog(this);
            LoadAddresses();

        }
        private void btnShowDebtor_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in lvlRates.Items)
            {
                if (listViewItem.Tag is AccountEntity account)
                {
                    foreach (var payment in account.PaymentDocuments)
                    {
                        if ((payment.Received - payment.Accrued) < 0)
                        {
                            listViewItem.BackColor = Color.Red;
                        }
                    }
                }
            }
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
            _form = new ProgressForm();
            _form.ShowDialog(this);
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
                    Account = txtAccount.Text,
                    AccountType = Convert(cmbPersonalAccountType.SelectedIndex),
                    HouseNumber = txtHouse.Text,
                    BuildingNumber = txtBuilding.Text,
                    ApartmentNumber = txtApartment.Text,
                    IsArchive = metroCheckBox1.Checked
                };

                CreateColumns(dateFrom.Value.Date, dateTo.Value.Date);

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
            else
            {
                MessageBox.Show("Ничего не найдено");
                return;
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
            using (var scope = _container.BeginLifetimeScope())
            {
                var searchService = scope.Resolve<ISearchService>();
                foreach (var entity in accountEntities)
                {
                    var paymentDocuments = searchService.FindPaymentDocuments(new SearchPaymentModel
                    {
                        AccountId = entity.Id,
                        From = dateFrom.Value.Date,
                        To = dateTo.Value.Date
                    });
                    if (!paymentDocuments.Any())
                    {
                        continue;
                    }
                    foreach (var documentEntity in paymentDocuments)
                    {
                        var listViewItem = new ListViewItem(new[]
                        {
                            entity.Account.ToString(),
                            documentEntity.Received.ToString(CultureInfo.CurrentCulture)
                        })
                        { Tag = entity };
                        lvlMonthReport.Items.Add(listViewItem);
                    }
                }
            }

            foreach (var accountEntity in accountEntities)
            {
                var item = new ListViewItem(new[] { accountEntity.Account.ToString() });

                if(accountEntity.PaymentDocuments.Count == 0)
                    continue;

                foreach (var documentEntity in accountEntity.PaymentDocuments)
                {
                    
                    item.SubItems.Add(documentEntity.Received.ToString(CultureInfo.CurrentCulture));
                }

                item.Tag = accountEntity;

                lvlMonthReport.Items.Add(item);
            }
        }

        private static AccountType Convert(int index)
        {
            return index == 0 ? AccountType.Municipal : AccountType.Private;
        }

        private void CreateColumns(DateTime from, DateTime to)
        {
            lvlMonthReport.Clear();
            lvlMonthReport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvlMonthReport.Columns.Add("Счет");

            do
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
                lvlMonthReport.Columns.Add(from.ToShortDateString());
                if (from.Month == to.Month)
                    break;

                from = from.AddMonths(1);
            } while (from.Month != to.Month);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
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
            foreach (ListViewItem item in lvlRates.CheckedItems)
            {
                DeleteItems(item);
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
                service.Update(document);

                lvlRates.Items.Remove(item);
            }
        }

        private void btnShowDeleteRates_Click(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked)
                LoadRates(0);
        }

        private void bthHideDeletedRates_Click(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked == false)
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
        }
        #endregion



        #endregion

        #region DiscountListView

        #region Buttons

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountOnAddressForm())
            {
                form.ShowDialog();
            }
        }

        private void btnDiscountOnAccount_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountAccountItemForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDiscount(form.DiscountModel);
                }
            }
        }

        private void btnAddDiscountPercent_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountPercentItem())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Успешно");
                }
            }
        }

        private void dtnDiscountDescription_Click(object sender, EventArgs e)
        {
            using (var form = new DiscountDescriptionItem())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Успешно");
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
                            "Счет", model.Account, model.Price, model.Description
                        })
                        { Tag = model };
                        lvlDiscounts.Items.Add(listViewItem);
                        break;
                    }
                case DiscountType.Address:
                    {
                        var listview = new ListViewItem(new[]
                        {
                            "Адрес",model.Address,model.Price,model.Description
                        })
                        { Tag = model };
                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region Load start value

        public void LoadDiscounts()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var discountService = scope.Resolve<IDiscountDocumentService>();
                var discounts = discountService.GetItems(x => x.IsDeleted == false).ToList();
                foreach (var discount in discounts)
                {
                    var type = discount.AccountId == 0 ? "Счет" : "Адрес";
                    //var listViewItem = new ListViewItem(new []
                    //{
                    //    type,discount.
                    //});
                }
            }
        }

        #endregion

        #endregion

        #region BackgroundWorker

        private void backgroundWorker1_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            if (e.Argument is string options)
            {
                foreach (var file in _files)
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var service = scope.ResolveNamed<IDataLoader>(options);
                        try
                        {
                            service.LoadData(file);
                        }
                        catch (FileLoadException)
                        {
                            MessageBox.Show("Не удалось загрузить данные из файла");
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
                MessageBox.Show(exception.Message);
            }
        }

        private void LoadRates(int flag)
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
                    if (rate.EndDate < DateTime.Now && flag == 1)
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
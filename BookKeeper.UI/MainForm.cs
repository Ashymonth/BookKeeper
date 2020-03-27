﻿using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Entities.Rates;
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
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BookKeeper.Data.Data.Entities.Discounts;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.Data.Services.EntityService.Discount;
using BookKeeper.UI.Models.Account;
using BookKeeper.UI.Models.Discount;
using BookKeeper.UI.Models.Rate;
using BookKeeper.UI.UI.Forms.Account;
using BookKeeper.UI.UI.Forms.Discount;
using BookKeeper.UI.UI.Forms.Rate;

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
                    AccountType = Convert(cmbPersonalAccountType.SelectedIndex),
                    HouseNumber = txtHouse.Text,
                    BuildingNumber = txtBuilding.Text,
                    ApartmentNumber = txtApartment.Text,
                    IsArchive = metroCheckBox1.Checked
                };
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
                MessageBox.Show("Улица не выбрана");
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
            lvlMonthReport.Clear();
            lvlMonthReport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvlMonthReport.Columns.Add("Счет");

            var accounts = accountEntities.ToList();

            var dates = accounts.Select(x => x.PaymentDocuments).FirstOrDefault();

            if (dates == null || dates.Count == 0)
            {
                MessageBox.Show("По данным критериям не найдено записей");
                return;
            }

            foreach (var date in dates.OrderBy(x=>x.PaymentDate))
            {
                lvlMonthReport.Columns.Add(date.PaymentDate.ToShortDateString());
            }

            foreach (var accountEntity in accounts)
            {
                var item = new ListViewItem(new[] { accountEntity.Account.ToString() });

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

                service.Delete(document);

                lvlRates.Items.Remove(item);
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

        private void btnShowDebtor_Click(object sender, EventArgs e)
        {
            lvlMonthReport.Clear();
            lvlMonthReport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvlMonthReport.Columns.Add("Счет");

            if (cmbStreet.SelectedValue is int streetId)
            {
                var searchModel = new SearchModel
                {
                    StreetId = streetId,
                    AccountType = Convert(cmbPersonalAccountType.SelectedIndex),
                    HouseNumber = txtHouse.Text,
                    BuildingNumber = txtBuilding.Text,
                    ApartmentNumber = txtApartment.Text,
                    IsArchive = metroCheckBox1.Checked
                };
                using (var scope = _container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<ISearchService>();
                    var result = service.FindAccounts(searchModel).ToList();
                    foreach (var entity in result)
                    {
                        var listView = new ListViewItem(new []
                        {
                            entity.Account.ToString()
                        });
                        var rateExist = entity.Location.Id != 0;
                        if (rateExist)
                        {
                            var rateService = scope.Resolve<IRateDocumentService>();
                            var rate = rateService.GetActiveRate(entity.Location.Id);

                            if (rate != null && rate.LocationId == entity.LocationId)
                            {
                                foreach (var document in entity.PaymentDocuments.Where(x=>x.IsDeleted == false && 
                                                                                          x.PaymentDate >= metroDateTime1.Value && 
                                                                                          x.PaymentDate <=metroDateTime2.Value))

                                {
                                    var accrued = rate.Price < document.Accrued ? rate.Price : document.Accrued;
                                    if ((document.Received - accrued) < 0)
                                    {
                                        var paymentService = scope.Resolve<IPaymentDocumentService>();
                                        var pastPayment = paymentService.GetItem(x =>
                                            x.PaymentDate == document.PaymentDate.AddMonths(-1) && 
                                            x.AccountId == entity.Id);

                                        if ((document.Received - pastPayment.Received) < 0)
                                        {
                                            listView.SubItems.Add(document.Received.ToString(CultureInfo.CurrentCulture));
                                            listView.BackColor = Color.Red;
                                        }

                                        lvlMonthReport.Items.Add(listView);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
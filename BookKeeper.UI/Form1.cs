using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.UI.UI.Forms;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BookKeeper.Data.Services;
using BookKeeper.Data.Services.EntityService.Address;
using BookKeeper.Data.Services.EntityService.Rate;
using BookKeeper.Data.Services.Load;

namespace BookKeeper.UI
{
    public partial class Form1 : MetroForm
    {
        private readonly Autofac.IContainer _container;

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
        private void btnAccept_Click(object sender, EventArgs e)
        {
            var searchModel = new SearchModel
            {
                StreetId = (int)cmbStreet.SelectedValue,
                AccountType = Convert(cmbPersonalAccountType.SelectedIndex),
                HouseNumber = txtHouse.Text,
                BuildingNumber = txtBuilding.Text,
                ApartmentNumber = txtApartment.Text,
            };

            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ISearchService>();
                var result = service.FindAccount(searchModel).ToList();

                if (result.Count() != 0)
                {
                    LoadAccountsInfo(result);
                }
            }
        }

        #region Load start value

        private void LoadAddresses()
        {
            try
            {
                cmbPersonalAccountType.SelectedIndex = 0;

                using (var scope = _container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<IStreetService>();

                    var result = service.GetItems().ToList();

                    cmbStreet.DataSource = result;
                    cmbStreet.DisplayMember = "StreetName";
                    cmbStreet.ValueMember = "Id";
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                Close();//TODO Add Create base function
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
                        });
                        lvlRates.Items.Add(listView);
                    }
                }
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
            { Tag = model };

            lvlRates.Items.Add(listViewItem);
        }

        private void LoadAccountsInfo(IEnumerable<AccountEntity> accountEntities)
        {
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

        private void btnLoadBase_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.Filter = "";
            }
        }

        private void btnLoadPayments_Click(object sender, EventArgs e)
        {
            var files = default(string[]);
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = @"Html files(*.html;*.htm)|*.html;*htm|All files(*.*)|*.*";
                dialog.Multiselect = true;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                files = dialog.FileNames;
            }

            using (var form = new ProgressForm())
            {
                form.ShowDialog(this);
                foreach (var fileName in files)
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        var service = scope.ResolveNamed<IDataLoader>("Html");
                        service.LoadData(fileName);
                    }
                }
            }
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            cntFilesMenu.Show(btnFiles, 0, btnFiles.Height);
        }

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
    }
}
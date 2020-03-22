using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Models;
using BookKeeper.Data.Services.EntityService;
using BookKeeper.UI.Models;
using BookKeeper.UI.UI.Forms;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BookKeeper.Data.Services.EntityService.Address;

namespace BookKeeper.UI
{
    public partial class Form1 : MetroForm
    {
        private readonly IContainer _container;
        private readonly List<AccountEntity> _accounts = new List<AccountEntity>();

        public Form1()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Initialize()
        {
            cmbPersonalAccountType.SelectedIndex = 0;

            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IAddressService>();
                var result = service.GetItems().ToList();
                if (result.Count != 0)
                {
                    cmbStreet.DataSource = result;
                    cmbStreet.DisplayMember = "StreetName";
                    cmbStreet.ValueMember = "Id";
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            metroContextMenu1.Show(metroButton1, 0, metroButton1.Height);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            var search = new SearchModel()
            {
                AddressId = (int)cmbStreet.SelectedValue,
                AccountType = cmbPersonalAccountType.SelectedIndex,
                HouseNumber = txtHouse.Text,
                BuildingNumber = txtBuilding.Text,
                ApartmentNumber = txtApartment.Text,
                IsArchive = metroCheckBox1.Checked
            };



            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IAccountService>();
                var result = service.GetWithInclude(x => x.StreetId == (int)cmbStreet.SelectedValue &&
                    x.AccountType == Convert(cmbPersonalAccountType.SelectedIndex), x => x.PaymentDocuments);


            }

        }
        private static AccountType Convert(int index)
        {
            return index == 0 ? AccountType.Municipal : AccountType.Private;
        }

        private void btnShowDebtor_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRate_Click(object sender, EventArgs e)
        {
            using (var rate = new RateItemForm())
            {
                var dialogResult = rate.ShowDialog(this);

                if (dialogResult == DialogResult.OK)
                {
                    LoadItems(rate.RateModel);
                }
            }
        }

        private void LoadItems(RateModel model)
        {
            var listViewItem = new ListViewItem(new[]
            {
                model.StreetId.ToString(),
                model.House,
                model.Building,
                model.Price.ToString(CultureInfo.CurrentCulture),
                model.Description,
            })
            { Tag = model };
            lvlRates.Items.Add(listViewItem);
        }
    }
}
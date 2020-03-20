using System;
using System.CodeDom;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Entities;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using MetroFramework.Forms;

namespace BookKeeper.UI
{
    public partial class Form1 : MetroForm
    {
        private readonly IContainer _container;


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
            var service = _container.Resolve<IAddressService>();
            var accountService = _container.Resolve<IAccountService>();
            var result = service.GetItems();
            var accountResult = accountService.GetItems();
            if (result != null)
            {
                cmbStreet.DataSource = result.ToList();
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
            using (var scope = _container.BeginLifetimeScope())
            {
                   
            }
        }

        private static AccountType Convert(int index)
        {
            return index == 0 ? AccountType.Municipal : AccountType.Private;
        }
    }
}

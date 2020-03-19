using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;
using MetroFramework.Forms;
using System;
using System.Linq;

namespace BookKeeper.UI.UI.Forms
{
    public partial class RateItemForm : MetroForm
    {
        public RateItemForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void Initialize()
        {
            var container = AutofacConfiguration.ConfigureContainer();
            var service = container.Resolve<IAddressService>();

            var result = service.GetItems();
            if (result != null)
            {
                cmbStreetName.DataSource = result.ToList();
                cmbStreetName.ValueMember = "StreetName";
               
            }
        }

        private void RateItemForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookKeepingDataSet.Streets' table. You can move, or remove it, as needed.
            this.streetsTableAdapter.Fill(this.bookKeepingDataSet.Streets);

        }
    }
}

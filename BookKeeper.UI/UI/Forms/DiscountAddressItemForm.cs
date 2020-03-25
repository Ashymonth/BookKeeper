using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService.Address;
using MetroFramework.Forms;
using IContainer = Autofac.IContainer;

namespace BookKeeper.UI.UI.Forms
{
    public partial class DiscountAddressItemForm : MetroForm
    {
        private readonly IContainer _container;

        public DiscountAddressItemForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void DiscountItemForm_Load(object sender, EventArgs e)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = _container.Resolve<IStreetService>();
                var streets = service.GetItems(x => x.IsDeleted == false);
                cmbStreets.DataSource = streets.ToList();
                cmbStreets.DisplayMember = "StreetName";
                cmbStreets.ValueMember = "Id";
            }
        }

        private void btnSaveDiscount_Click(object sender, EventArgs e)
        {

        }
    }
}

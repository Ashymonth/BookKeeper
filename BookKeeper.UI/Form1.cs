using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Data.Repositories;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services.EntityService;

namespace BookKeeper.UI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
          
            InitializeComponent();
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
            var container = AutofacConfiguration.ConfigureContainer();

            var service = container.Resolve<IAddressService>();

            var result = service.GetAddresses();

            if (result != null)
                comboBox1.DataSource =  result.ToList();
        }
    }
}

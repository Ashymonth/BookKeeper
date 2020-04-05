using BookKeeper.UI.Helpers;
using MetroFramework.Forms;

namespace BookKeeper.UI.UI.Forms.Houses
{
    public partial class DeleteHouseForm : MetroForm
    {
        private readonly DataSourceHelper _dataSourceHelper;

        public DeleteHouseForm()
        {
            InitializeComponent();
            _dataSourceHelper = new DataSourceHelper();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            _dataSourceHelper.LoadAddresses(cmbStreets);
        }

        private void DeleteHouseForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}

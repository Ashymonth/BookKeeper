using BookKeeper.UI.Helpers;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace BookKeeper.UI.UI.Forms.Rate
{
    public partial class RatePriceForm : MetroForm
    {


        public RatePriceForm()
        {
            InitializeComponent();
        }
        public decimal Price { get; set; }
        private void btnChange_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
                MessageBoxHelper.ShowWarningMessage("Заполните поле", this);

            try
            {
                Price = Convert.ToDecimal(txtPrice.Text);
                if (Price <= 0)
                {
                    MessageBoxHelper.ShowWarningMessage("Цена должна быть больше 0", this);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
            catch (OverflowException)
            {
                MessageBoxHelper.ShowWarningMessage("Число слишком большойе", this);
                return;
            }
            catch (FormatException)
            {
                MessageBoxHelper.ShowWarningMessage("Форамат числа указан не верно. Используйте точку для разделения", this);
                return;
            }
        }
    }
}

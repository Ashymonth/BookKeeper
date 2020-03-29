using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace BookKeeper.UI.Helpers
{
    public class MessageBoxHelper
    {
        public static void ShowWarningMessage(string message, MetroForm form)
        {
            MessageBox.Show(message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowCompeteMessage(string message, MetroForm form)
        {
            MessageBox.Show(message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

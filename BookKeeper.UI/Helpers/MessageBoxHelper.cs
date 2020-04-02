﻿using MetroFramework.Forms;
using System.Windows.Forms;

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

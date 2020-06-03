using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BookKeeper.UI.Settings.Models;
using BookKeeper.UI.Settings.Services;

namespace BookKeeper.UI.Settings
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().Any(textBox => string.IsNullOrWhiteSpace(textBox.Text)))
            {
                MessageBox.Show(@"All fields must be filled");
                return;
            }

            var commandsService = new SqlCommandsService();
            SqlCommandsService.CreateDataBase(new SettingsHandler(){DataBaseName = txtName.Text,Login = txtLogin.Text,Password = txtPassword.Text});
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = @"configuration file (*.exe.config;.*config)|*.exe.config;*.config";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }
    }
}

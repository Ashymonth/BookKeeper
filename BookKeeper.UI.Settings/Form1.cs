using BookKeeper.Settings.Models;
using BookKeeper.Settings.Services;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BookKeeper.Settings
{
    public partial class MainForm : Form
    {
        private string _configPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _configPath = ConfigurationManager.AppSettings["ConfigPath"];
            if (Directory.Exists(_configPath) == false)
            {
                MessageBox.Show(@"Path to file not found. Specify the correct path in app.config");
                return;
            }

            if (File.Exists(_configPath))
            {
                MessageBox.Show("File not found");
                return;
            }
            try
            {
                var result = ConfigFileService.Load(_configPath);
                if (result == null)
                {
                    MessageBox.Show(@"Configuration file was not found. Specify path in app.config");
                    return;
                }

                lblConnectionString.Text = result.ConnectionString;
                txtName.Text = result.InitialCatalog;
                txtLogin.Text = result.UserID;
                txtPassword.Text = result.Password;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(@"Connection string in file not found. Specify path to file in app.config");
                Environment.Exit(-1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().Any(textBox => string.IsNullOrWhiteSpace(textBox.Text)))
            {
                MessageBox.Show(@"All fields must be filled");
                return;
            }

            var result = SqlCommandsService.CreateDataBase(new SettingsHandler() { DataBaseName = txtName.Text, Login = txtLogin.Text, Password = txtPassword.Text });
            if (result == null)
                return;

            if (ConfigFileService.Write(result, _configPath))
            {
                MessageBox.Show(@"Done");
                lblConnectionString.Text = result.ConnectionString;
                return;
            }
            MessageBox.Show(@"Error");
        }
    }
}
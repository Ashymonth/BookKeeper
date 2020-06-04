using BookKeeper.Settings.Models;
using BookKeeper.Settings.Services;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using BookKeeper.Data.Infrastructure;
using BookKeeper.Data.Services;
namespace BookKeeper.Settings
{
    public partial class MainForm : Form
    {
        private string _configPath;
        private readonly IContainer _container;

        public MainForm()
        {
            InitializeComponent();
            _container = AutofacConfiguration.ConfigureContainer();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _configPath = ConfigurationManager.AppSettings["ConfigPath"];

            if (File.Exists(_configPath) == false)
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

            using (var scope = _container.BeginLifetimeScope() )
            {
                var backupService = scope.Resolve<IBackupService>();
                using (var dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        backupService.RestoreFromBackup(dialog.FileName);
                    }
                }
                

            }
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
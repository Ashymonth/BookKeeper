using BookKeeper.Settings.Models;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace BookKeeper.Settings.Services
{
    public static class SqlCommandsService
    {
        public static SqlConnectionStringBuilder CreateDataBase(SettingsHandler settings)
        {
            var connectionString = $"data source=(localdb)\\MSSQLLocalDB;Initial Catalog={settings.DataBaseName};database=master";

            var template = File.ReadAllText("Scripts\\DataBase.txt");

            var createDataBase = string.Format(template, settings.DataBaseName);

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand(createDataBase, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    var user = File.ReadAllText("Scripts\\User.txt");
                    var createUser = string.Format(user,settings.Login,settings.Password,settings.DataBaseName);

                    using (var command = new SqlCommand(createUser, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

                return new SqlConnectionStringBuilder
                {
                    DataSource = @"(localdb)\MSSQLLocalDB",
                    InitialCatalog = settings.DataBaseName,
                    UserID = settings.Login,
                    Password = settings.Password
                };
            }
        }
    }
}
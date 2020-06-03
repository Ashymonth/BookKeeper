using BookKeeper.UI.Settings.Models;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace BookKeeper.UI.Settings.Services
{
    public class SqlCommandsService
    {
        public static void CreateDataBase(SettingsHandler settings)
        {
            const string connectionString = "data source=(localdb)\\MSSQLLocalDB;database=master";

            var template = File.ReadAllText("Scripts\\DataBase.sql");

            var logName = Path.ChangeExtension(settings.DataBasePath, ".log");

            var createDataBase = string.Format(template,
                settings.DataBaseName,
                settings.DataBaseName,
                settings.DataBasePath,
                $"{settings.DataBaseName}_Log",
                logName);

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand(createDataBase, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    var user = File.ReadAllText("Scripts\\User.sql");

                    var createUser = string.Format(user, settings.DataBaseName, settings.Login, settings.Password);

                    using (var command = new SqlCommand(createUser, connection))
                    {
                        command.ExecuteNonQueryAsync();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
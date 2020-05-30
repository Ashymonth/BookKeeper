using BookKeeper.Settings.Models;
using System;
using System.Data.SqlClient;
using System.IO;

namespace BookKeeper.Settings.Services
{
    public interface ISqlCommandsService
    {
        void CreateUser(string login, string password, string connectionString);

        void CreateDataBase(SettingsHandler settings);
    }

    public class SqlCommandsService : ISqlCommandsService
    {
        public void CreateUser(string login, string password, string connectionString)
        {
            var read = File.ReadAllText("Scripts\\User.sql");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var createUser = string.Format(read, login, password);

                using (var command = new SqlCommand(createUser, connection))
                {
                    command.ExecuteReader();
                }
                connection.Close();
            }
        }

        public void CreateDataBase(SettingsHandler settings)
        {
            const string connectionString = "data source=(localdb)\\MSSQLLocalDB;Integrated Security=True;database=master";

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
                        command.ExecuteReader();

                        Console.WriteLine("\nDone");
                        Console.ReadKey();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
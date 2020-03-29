using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.IO;
using ClosedXML.Excel.CalcEngine.Exceptions;

namespace BookKeeper.Data.Services
{
    public class BackupService
    {
        private const string Database = "BookKeeper";

        private const string ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void CreateBackup(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sqlCommand =
                    $@"BACKUP DATABASE [{Database}] TO DISK = '{folder}\{DateTime.Now.ToFileTime()}.bak' WITH INIT , NOUNLOAD ,  NOSKIP , STATS = 10, NOFORMAT";
                using (var com = new SqlCommand(sqlCommand, connection))
                {
                    com.ExecuteReader();
                }
                connection.Close();
            }
        }

        public static void RestoreFromBackup(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException();

            if (file == null)
                throw new NullReferenceException();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sqlCommand = $"ALTER DATABASE [{Database}] SET Single_User WITH Rollback Immediate RESTORE DATABASE [{Database}] FROM DISK='{file}' WITH REPLACE;";

                using (var command = new SqlCommand(sqlCommand, connection))
                {
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }
    }
}

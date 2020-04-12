using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace BookKeeper.Data.Services
{
    public interface IBackupService
    {
        string CreateBackup();

        void RestoreFromBackup(string file);

        void CreateBackUpInAWeek();
    }

    public class BackupSettings
    {
        public string BackupFolder { get; set; }

        public string DatabaseName { get; set; }

        public string BackupFileNameTemplate { get; set; }

        public string ConnectionString { get; set; }
    }

    public class BackupService : IBackupService
    {
        private const string DefaultDirectory = "Backup";

        private readonly BackupSettings _settings;
        private const string RestoreToSameDbQuery = "USE MASTER ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [{0}] FROM DISK='{1}' WITH REPLACE alter database [{0}] set multi_user;";
        private const string RestoreToNewDbQuery = "ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [{0}] FROM DISK='{1}' WITH REPLACE;";
        private const string BackupDbToFileQuery = @"BACKUP DATABASE [{0}] TO DISK = '{1}' WITH INIT , NOUNLOAD ,  NOSKIP , STATS = 10, NOFORMAT";

        public BackupService(BackupSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public string CreateBackup()
        {
            if (!Directory.Exists(DefaultDirectory))
                Directory.CreateDirectory(DefaultDirectory);

            using (var connection = new SqlConnection(_settings.ConnectionString))
            {
                connection.Open();

                var backupFileName = DateTime.Now.ToString("yyyy-MM-dd_hhmmsss");

                var sqlCommand = string.Format(BackupDbToFileQuery, connection.Database, Path.Combine(Directory.GetCurrentDirectory(), Path.Combine(DefaultDirectory, $"{backupFileName}.bak")));

                using (var com = new SqlCommand(sqlCommand, connection))
                {
                    com.ExecuteReader();
                }
                connection.Close();

                return backupFileName;
            }
        }

        public void RestoreFromBackup(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException(nameof(file));

            if (!File.Exists(file))
                throw new FileNotFoundException();

            using (var connection = new SqlConnection(_settings.ConnectionString))
            {
                connection.Open();

                var sqlCommand = connection.Database.Equals(_settings.DatabaseName, StringComparison.OrdinalIgnoreCase)
                    ? string.Format(RestoreToSameDbQuery, _settings.DatabaseName, file)
                    : string.Format(RestoreToNewDbQuery, _settings.DatabaseName, file);

                using (var command = new SqlCommand(sqlCommand, connection))
                {
                    command.ExecuteReader(); 
                    connection.Close();
                }
            }
        }

        public void CreateBackUpInAWeek()
        {
            var date = new DateTime(DateTime.Today.Year,DateTime.Today.Month,DateTime.Today.Day);

            if (date.DayOfWeek == DayOfWeek.Monday)
                CreateBackup();
        }
    }
}

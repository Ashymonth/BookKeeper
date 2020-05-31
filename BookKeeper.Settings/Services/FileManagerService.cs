using BookKeeper.Settings.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace BookKeeper.Settings.Services
{
    public interface IFileManagerService
    {
        void Save(SettingsHandler settings, string configPath);

        SettingsHandler Load();
    }

    public class FileManagerService : IFileManagerService
    {
        private const string PathToSaveFile = "settings.json";

        private readonly IConfigFileService _configFileService;

        private readonly ISqlCommandsService _sqlCommands;

        public FileManagerService(IConfigFileService configFileService, ISqlCommandsService sqlCommands)
        {
            _configFileService = configFileService;
            _sqlCommands = sqlCommands;
        }

        public void Save(SettingsHandler settings, string configPath)
        {
            try
            {
                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);

                using (var stream = File.Open(PathToSaveFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var array = Encoding.Default.GetBytes(json);
                   stream.Write(array,0,array.Length);
                }

                var connectionString = _configFileService.Write(settings, configPath);

                _sqlCommands.CreateDataBase(settings);
                _sqlCommands.CreateUser(settings.Login, settings.Password, connectionString);
            }

            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }

        public SettingsHandler Load()
        {
            if (File.Exists(PathToSaveFile) == false)
            {
                using (File.Open(PathToSaveFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    return new SettingsHandler();
                }
                
            }

            var jsonString = File.ReadAllText(PathToSaveFile);
            return JsonConvert.DeserializeObject<SettingsHandler>(jsonString) ?? new SettingsHandler();
        }
    }
}
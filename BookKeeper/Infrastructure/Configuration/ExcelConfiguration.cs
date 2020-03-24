using Newtonsoft.Json;
using System.IO;

namespace BookKeeper.Data.Infrastructure.Configuration
{
    public class ExcelConfiguration : IConfiguration<ExcelConfiguration>
    {
        private const string ConfigurationFile = "ExcelConfiguration.json";

        private const string Folder = "src\\Configuration";

        public string MunicipalMark { get; set; }

        public string StartColumn { get; set; }

        public int ServiceProviderCode { get; set; }

        public string ServiceProviderCodeValue { get; set; }

        public int DistrictName { get; set; }

        public int DistrictType { get; set; }

        public int AccrualMonth { get; set; }

        public int StreetName { get; set; }

        public int HouseNumber { get; set; }

        public int CorpusNumber { get; set; }

        public int ApartmentNumber { get; set; }

        public int PersonalAccount { get; set; }

        public void Save()
        {
            var configuration = new ExcelConfiguration();

            var jsonString = JsonConvert.SerializeObject(configuration, Formatting.Indented);

            var path = $"{Folder}\\{ConfigurationFile}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(Folder);

            if (File.Exists(path))
                File.WriteAllText(path, jsonString);
            else
            {
                File.Create(path);
                File.WriteAllText(path, jsonString);
            }
        }

        public ExcelConfiguration Load()
        {
             var path = $"{Folder}\\{ConfigurationFile}";

            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);

            if (!File.Exists(path))
            {
                File.Create(path);
                return null;
            }

            var jsonString = File.ReadAllText(path);
            var configuration = JsonConvert.DeserializeObject<ExcelConfiguration>(jsonString);
            return configuration;
        }
    }
}
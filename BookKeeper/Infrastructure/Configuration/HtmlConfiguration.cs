using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace BookKeeper.Data.Infrastructure.Configuration
{
    public class HtmlConfiguration : IConfiguration<HtmlConfiguration>
    {
        private const string ConfigurationFile = "HtmlConfig.json";

        private const string Folder = "src\\Configuration";

        public string HeaderId { get; set; }

        public int DistrictCell { get; set; }

        public int DocumentDateCell { get; set; }

        public int ApartmentNumberCell { get; set; }

        public int PersonalAccountCell { get; set; }

        public int AccruedCell { get; set; }

        public int ReceivedCell { get; set; }

        public string Address { get; set; }

        public string LastRow { get; set; }

        public string LastTableRow { get; set; }

        public int AccountLength { get; set; }

        public void Save()
        {
            var configuration = new HtmlConfiguration();

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

        public HtmlConfiguration Load()
        {
            var path = $"{Folder}\\{ConfigurationFile}";

            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);

            if (!File.Exists(path))
            {
                File.Create(path);
                return null;
            }

            var jsonString = File.ReadAllText(path,Encoding.UTF8);
            var configuration = JsonConvert.DeserializeObject<HtmlConfiguration>(jsonString);
            return configuration;
        }
    }
}
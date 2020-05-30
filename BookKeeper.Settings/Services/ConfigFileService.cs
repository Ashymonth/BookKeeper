using BookKeeper.Settings.Models;
using System.Configuration;
using System.Xml;

namespace BookKeeper.Settings.Services
{
    public interface IConfigFileService
    {
        string Write(SettingsHandler settings, string configPath);
    }

    public class ConfigFileService : IConfigFileService
    {
        private const string Template = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog={0};AttachDbFileName = {1};User id={2}; password={3}";

        public string Write(SettingsHandler settings, string configPath)
        {
            var connectionString = string.Format(Template, settings.DataBaseName, settings.DataBasePath, settings.Login, settings.Password);
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(configPath);

            if (xmlDoc.DocumentElement == null)
                return null;

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("connectionStrings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes != null)
                        {
                            node.Attributes[0].Value = settings.DataBaseName;
                            node.Attributes[1].Value = connectionString;
                        }
                    }
                }

                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes != null && node.Attributes[0].Value.Equals("ConnectionName"))
                        {
                            node.Attributes[1].Value = settings.DataBaseName;
                        }
                    }
                }
            }

            xmlDoc.Save(configPath);

            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");

            return connectionString;
        }
    }
}
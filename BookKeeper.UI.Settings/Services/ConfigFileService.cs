using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;

namespace BookKeeper.Settings.Services
{
    public static class ConfigFileService
    {
        public static bool Write(SqlConnectionStringBuilder builder, string configPath)
        {
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(configPath);

            if (xmlDoc.DocumentElement == null)
                return false;

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("connectionStrings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes != null)
                        {
                            node.Attributes[0].Value = builder.InitialCatalog;
                            node.Attributes[1].Value = builder.ConnectionString;
                        }
                    }
                }

                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes != null && node.Attributes[0].Value.Equals("ConnectionName"))
                        {
                            node.Attributes[1].Value = builder.InitialCatalog;
                        }
                    }
                }
            }

            xmlDoc.Save(configPath);

            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");

            return true;
        }

        public static SqlConnectionStringBuilder Load(string configPath)
        {
            var xmlDoc = new XmlDocument();
            if(string.IsNullOrWhiteSpace(configPath))
                throw new ArgumentNullException(nameof(configPath));

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
                          return new SqlConnectionStringBuilder(node.Attributes[1].Value);
                        }
                    }
                }
            }

            return null;
        }
    }
}
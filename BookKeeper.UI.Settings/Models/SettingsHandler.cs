namespace BookKeeper.UI.Settings.Models
{
    public class SettingsHandler
    {
        public string DataBaseName { get; set; }

        public string DataBasePath { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Information => $"Name: {DataBaseName}" +
                                     $"\nPath: {DataBasePath}  " +
                                     $"\nLogin: {Login}" +
                                     $"\nPassword: {Password}";
    }
}
using BookKeeper.Settings.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace BookKeeper.Settings.Services
{
    public interface IInputService
    {
        string Validate(string text);

        string ValidateName(string text, SettingsHandler settings);

        string ValidateTargetPath();

        string ValidatePath(string text, SettingsHandler settings);

        bool ValidateOnSave(SettingsHandler settings);
    }

    public class InputService : IInputService
    {
        public string Validate(string text)
        {
            while (true)
            {
                Console.WriteLine($"\n{text}");
                var result = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(result))
                {
                    continue;
                }
                return result;
            }
        }

        public string ValidateName(string text, SettingsHandler settings)
        {
            while (true)
            {
                Console.WriteLine($"\n{text}");
                var result = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(result))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(settings.DataBasePath) == false)
                {
                    settings.DataBasePath = settings.DataBasePath.Replace(settings.DataBaseName, result);
                }

                return result;
            }
        }

        public string ValidateTargetPath()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "configuration file (*.exe.config;.*config)|*.exe.config;*.config";
                while (true)
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!File.Exists(dialog.FileName))
                        {
                            Console.WriteLine("\nFile not found");
                            continue;
                        }

                        if (dialog.FileName == null)
                        {
                            Console.WriteLine("\nFile is empty");
                            continue;
                        }

                        return dialog.FileName;
                    }

                    Console.WriteLine("\nPlease, select file");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                }
            }
        }

        public string ValidatePath(string text, SettingsHandler settings)
        {
            const string template = "{0}\\{1}.mdf";
            
            using (var dialog = new FolderBrowserDialog())
            {
                while (true)
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        return string.Format(template, dialog.SelectedPath, settings.DataBaseName);
                    }
                }
            }
        }

        public bool ValidateOnSave(SettingsHandler settings)
        {
            if (settings == null)
                return false;

            return string.IsNullOrWhiteSpace(settings.Login) == false &&
                   string.IsNullOrWhiteSpace(settings.Password) == false &&
                   string.IsNullOrWhiteSpace(settings.DataBaseName) == false &&
                   string.IsNullOrWhiteSpace(settings.DataBasePath) == false;
        }
    }
}
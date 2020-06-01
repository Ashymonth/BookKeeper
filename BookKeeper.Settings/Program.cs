using BookKeeper.Settings.Infrastructure;
using BookKeeper.Settings.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookKeeper.Settings
{
    internal static class Program
    {
        private static readonly IFileManagerService FileManagerService;

        private static readonly IInputService InputService;

        static Program()
        {
            var services = ApplicationConfiguration.Configure();
            FileManagerService = services.GetRequiredService<IFileManagerService>();
            InputService = services.GetRequiredService<IInputService>();
        }

        [STAThread]
        private static void Main(string[] args)
        {
            var settings = FileManagerService.Load();
            var on = true;

            Console.WriteLine("Database setup wizard");
            Console.WriteLine("Input path to target config file");

            var configPath = InputService.ValidateTargetPath();
            do
            {
                #region Menu

                Console.WriteLine();
                Console.WriteLine($"Current file: {configPath}");
                Console.WriteLine("Select actions:");
                Console.WriteLine("1. Create DataBase name");
                Console.WriteLine("2. Create Database path");
                Console.WriteLine("3. Create new user");
                Console.WriteLine("4. View current information");
                Console.WriteLine("5. Save");
                Console.WriteLine("6. Select new config file");
                Console.WriteLine("7. Exit");
                Console.WriteLine("\n");

                #endregion

                var result = Console.ReadKey();

                switch (result.KeyChar)
                {
                    case '1':
                        var name = InputService.ValidateName("Input name",settings);
                        settings.DataBaseName = name;
                        SuccessMessage();
                        break;

                    case '2':
                        var path = InputService.ValidatePath("Input path", settings);
                        settings.DataBasePath = path;
                        SuccessMessage();
                        break;

                    case '3':
                        var login = InputService.Validate("Input login");
                        settings.Login = login;

                        var password = InputService.Validate("Input login password");
                        settings.Password = password;
                        SuccessMessage();
                        break;

                    case '4':
                        Console.WriteLine($"\n{settings.Information}");
                        SuccessMessage();
                        Console.WriteLine("Press any button");
                        Console.ReadKey();
                        break;

                    case '5':
                        if (InputService.ValidateOnSave(settings) == false)
                        {
                            Console.Clear();
                            Console.WriteLine("\nFields must be filled");
                            Console.WriteLine(settings.Information);
                            Console.ReadKey();
                            continue;
                        }

                        FileManagerService.Save(settings, configPath);
                        SuccessMessage();
                        break;
                    case '6':
                        configPath = InputService.ValidateTargetPath();
                        SuccessMessage();
                        break;
                    case '7':
                        on = false;
                        break;
                    default:
                        continue;
                }
            } while (on);
        }

        private static void SuccessMessage()
        {
            Console.WriteLine("Success");
        }
    }
}
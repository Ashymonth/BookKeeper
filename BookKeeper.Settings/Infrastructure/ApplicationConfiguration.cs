using BookKeeper.Settings.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookKeeper.Settings.Infrastructure
{
    public static class ApplicationConfiguration
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddSingleton<IFileManagerService,FileManagerService>()
                .AddSingleton<IConfigFileService,ConfigFileService>()
                .AddSingleton<IInputService,InputService>()
                .AddSingleton<ISqlCommandsService,SqlCommandsService>()
                .BuildServiceProvider();
        }
    }
}
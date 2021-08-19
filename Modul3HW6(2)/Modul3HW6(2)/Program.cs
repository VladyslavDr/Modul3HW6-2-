using Microsoft.Extensions.DependencyInjection;
using Modul3HW6_2_.Services;
using Modul3HW6_2_.Services.Abstractions;

namespace Modul3HW6_2_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviseProvider = new ServiceCollection()
                .AddTransient<ILoggerService, LoggerService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var starter = serviseProvider.GetService<Starter>();
            starter.Run();
        }
    }
}

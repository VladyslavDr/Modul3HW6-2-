using System;
using System.Threading;
using System.Threading.Tasks;
using Modul3HW6_2_.Enums;
using Modul3HW6_2_.Services.Abstractions;

namespace Modul3HW6_2_
{
    public class Starter
    {
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);

        private IConfigService _config;
        private ILoggerService _loggerService;
        private IFileService _fileService;
        public Starter(
            IConfigService config,
            ILoggerService loggerService,
            IFileService fileService)
        {
            _config = config;
            _loggerService = loggerService;
            _fileService = fileService;
        }

        public void Run()
        {
            _loggerService.BackUpСondition += BackUp;

            Task.Run(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    var x = i;
                    Task.Run(async () => { await WriteAsync($"Method2 {x}"); });
                }
            });

            Task.Run(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    var x = i;
                    Task.Run(async () => { await WriteAsync($"Method1 {x}"); });
                }
            });

            Console.ReadLine();
        }

        private void BackUp()
        {
            Console.WriteLine("Keeping progress");
            _fileService.MakeBackUp();
        }

        private async Task WriteAsync(string message)
        {
            await _semaphoreSlim.WaitAsync();

            await Task.Run(() => _loggerService.CreateLog(LogStatus.INFO, message));

            _semaphoreSlim.Release();
        }
    }
}

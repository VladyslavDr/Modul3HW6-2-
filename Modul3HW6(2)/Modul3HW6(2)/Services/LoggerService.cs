using System;
using Modul3HW6_2_.Enums;
using Modul3HW6_2_.Services.Abstractions;

namespace Modul3HW6_2_.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfigService _config;
        private readonly IFileService _fileService;
        private int _countLines;
        public LoggerService(
            IFileService fileService,
            IConfigService config)
        {
            _fileService = fileService;
            _config = config;
            _countLines = 0;
        }

        public event Action BackUpСondition;

        public void CreateLog(LogStatus logType, string message)
        {
            var log = $"{DateTime.UtcNow.ToString(_config.LoggerConfig.TimeFormat)} {logType}: {message}";
            Console.WriteLine(log);
            _fileService.WriteToFile(log);
            _countLines++;
            BackUpControl(_countLines);
        }

        private void BackUpControl(int countLines)
        {
            if (countLines % _config.LoggerConfig.NumbeOfRowsToBackUp == 0)
            {
                BackUpСondition.Invoke();
            }
        }
    }
}

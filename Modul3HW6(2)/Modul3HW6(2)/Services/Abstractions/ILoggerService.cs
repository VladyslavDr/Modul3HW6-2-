using System;
using Modul3HW6_2_.Enums;

namespace Modul3HW6_2_.Services.Abstractions
{
    public interface ILoggerService
    {
        public event Action BackUpСondition;
        public void CreateLog(LogStatus logType, string message);
    }
}

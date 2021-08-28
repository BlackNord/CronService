using System;
using CronService.Database.Services.Interfaces;

namespace CronService.Database.Services
{
    public class LogFileParser : ILogFileParser
    {
        public DateTimeOffset GetLatestTimeStamp(string logFileContent)
        {
            var result = DateTimeOffset.Now.Subtract(TimeSpan.FromMinutes(5));
            return result;
        }
    }
}
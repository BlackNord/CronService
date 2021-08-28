using System;
using CronService.Database.Services.Interfaces;
using CronService.Utils.Extensions;

namespace CronService.Database.Services
{
    public class LogFileParser : ILogFileParser
    {
        public DateTimeOffset GetLatestTimeStamp(string logFileContent)
        {
            if (logFileContent.IsNullOrWhitespace())
            {
                throw new ArgumentNullException(nameof(logFileContent));
            }

            var canParse = DateTimeOffset.TryParse(logFileContent, out var result);
            if (!canParse)
            {
                throw new InvalidOperationException($"Can't parse content: '{logFileContent}' to DateTimeOffset");
            }

            return result;
        }
    }
}
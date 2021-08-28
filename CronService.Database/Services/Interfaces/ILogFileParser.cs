using System;

namespace CronService.Database.Services.Interfaces
{
    public interface ILogFileParser
    {
        DateTimeOffset GetLatestTimeStamp(string logFileContent);
    }
}
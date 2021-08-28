using System;
using CronService.Database.Infrastructure;
using CronService.Database.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace CronService.Database.Services
{
    public class LogFileProvider : ILogFileProvider
    {
        private readonly IOptions<DatabaseSettings> options;

        public LogFileProvider(IOptions<DatabaseSettings> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public string GetLogFileContent()
        {
            var settings = options.Value;
            return "test";
        }
    }
}
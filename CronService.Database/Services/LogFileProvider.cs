﻿using System;
using System.IO;
using System.Threading.Tasks;
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

        public async Task<string> GetLogFileContent()
        {
            var settings = options.Value;

            var path = settings.LogFilePath;
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Can't find file with location: '{path}'");
            }

            using (var reader = new StreamReader(path))
            {
                var content = await reader.ReadToEndAsync();
                return content;
            }
        }
    }
}
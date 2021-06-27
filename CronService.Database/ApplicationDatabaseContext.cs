using System;
using CronService.Database.Infrastructure;
using Microsoft.Extensions.Options;

namespace CronService.Database
{
    public class ApplicationDatabaseContext
    {
        private readonly IOptions<DatabaseSettings> options;

        public ApplicationDatabaseContext(IOptions<DatabaseSettings> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
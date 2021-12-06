using System;
using System.Threading.Tasks;
using CronService.Database.Infrastructure;
using CronService.Database.Interfaces;
using CronService.Database.Services.Interfaces;
using Microsoft.Extensions.Options;
using Npgsql;

namespace CronService.Database.Services
{
    public class StoredProcedureExecutor : IStoredProcedureExecutor
    {
        private readonly IOptions<DatabaseSettings> options;
        private readonly IApplicationDatabaseContext applicationDatabaseContext;

        public StoredProcedureExecutor(
            IOptions<DatabaseSettings> options,
            IApplicationDatabaseContext applicationDatabaseContext)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.applicationDatabaseContext = applicationDatabaseContext ?? throw new ArgumentNullException(nameof(applicationDatabaseContext));
        }

        public async Task ExecuteQuery()
        {
            var settings = options.Value;
            var connection = applicationDatabaseContext.Connection;

            using (var command = new NpgsqlCommand(settings.Query, connection))
            {
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
using CronService.Database.Infrastructure;
using CronService.Database.Interfaces;
using Microsoft.Extensions.Options;
using Npgsql;
using System;

namespace CronService.Database
{
    public sealed class ApplicationDatabaseContext : IApplicationDatabaseContext
    {
        private readonly IOptions<DatabaseSettings> options;
        private readonly Lazy<NpgsqlConnection> connection;

        public NpgsqlConnection Connection => connection.Value;

        public ApplicationDatabaseContext(IOptions<DatabaseSettings> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));

            connection = new Lazy<NpgsqlConnection>(() => GetConnection());
        }

        private NpgsqlConnection GetConnection()
        {
            var settings = options.Value;

            var result = new NpgsqlConnection(settings.ConnectionString);
            result.OpenAsync();

            return result;
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
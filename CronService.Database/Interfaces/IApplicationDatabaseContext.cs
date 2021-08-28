using Npgsql;
using System;

namespace CronService.Database.Interfaces
{
    public interface IApplicationDatabaseContext : IDisposable
    {
        NpgsqlConnection Connection { get; }
    }
}
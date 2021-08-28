using System;
using CronService.Database.Interfaces;
using CronService.Database.Services;
using CronService.Database.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CronService.Database.Extensions
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IApplicationDatabaseContext, ApplicationDatabaseContext>();
            services.AddScoped<IStoredProcedureExecutor, StoredProcedureExecutor>();
            services.AddScoped<ILogFileProvider, LogFileProvider>();
            services.AddScoped<ILogFileParser, LogFileParser>();

            return services;
        }
    }
}
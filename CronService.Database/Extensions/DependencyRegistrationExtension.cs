using System;
using CronService.Database.Interfaces;
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

            return services;
        }
    }
}
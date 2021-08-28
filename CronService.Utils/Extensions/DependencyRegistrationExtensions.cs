using System;
using CronService.Utils.Interfaces;
using CronService.Utils.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CronService.Utils.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
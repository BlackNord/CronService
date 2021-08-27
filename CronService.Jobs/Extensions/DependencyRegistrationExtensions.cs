using CronService.Jobs.Factories;
using CronService.Jobs.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using CronService.Jobs.Interfaces;

namespace CronService.Jobs.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection AddJobs(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddHostedService<JobsHostedService>();

            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerContext, SchedulerContext>();
            services.AddSingleton<IJobDetailsFactory, DefaultJobDetailFactory>();
            services.AddSingleton<IJobTriggerFactory, DefaultJobTriggerFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<IScheduleProvider, ScheduleProvider>();

            services.AddScoped<DatabaseCallJobJob>();

            return services;
        }
    }
}
using System;
using CronService.Jobs.Factories;
using CronService.Jobs.Factories.Interfaces;
using CronService.Jobs.Jobs;
using CronService.Jobs.Jobs.Base;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

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

            services.AddSingleton<IJobDetailsFactory, DefaultJobDetailFactory>();
            services.AddSingleton<IJobTriggerFactory, DefaultJobTriggerFactory>();
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<IScheduleProvider, ScheduleProvider>();
            services.AddSingleton<JobRunner>();

            services.AddHostedService<JobsHostedService>();

            services.AddScoped<DatabaseCallJobJob>();
            services.AddScoped<LogFileExamineJob>();

            services.AddSingleton(x => x.GetRequiredService<IScheduleProvider>().Schedules);

            return services;
        }
    }
}
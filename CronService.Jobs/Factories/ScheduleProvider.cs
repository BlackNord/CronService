using CronService.Jobs.Infrastructure;
using CronService.Jobs.Jobs;
using CronService.Jobs.Schedules;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using CronService.Jobs.Interfaces;

namespace CronService.Jobs.Factories
{
    public class ScheduleProvider : IScheduleProvider
    {
        private readonly IOptions<JobSettings> options;

        public ScheduleProvider(IOptions<JobSettings> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public IEnumerable<IJobSchedule> GetSchedules()
        {
            var settings = options.Value;
            var result = new List<IJobSchedule>()
            {
                new JobSchedule()
                {
                    JobType = typeof(DatabaseCallJobJob),
                    CronExpression = settings.RepeatInterval
                }
            };

            return result;
        }
    }
}
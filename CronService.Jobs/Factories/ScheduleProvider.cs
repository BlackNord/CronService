using CronService.Jobs.Factories.Interfaces;
using CronService.Jobs.Infrastructure;
using CronService.Jobs.Jobs;
using CronService.Jobs.Schedules;
using CronService.Jobs.Schedules.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace CronService.Jobs.Factories
{
    public class ScheduleProvider : IScheduleProvider
    {
        private readonly IOptions<JobSettings> options;
        private readonly Lazy<IEnumerable<IJobSchedule>> schedules;

        public IEnumerable<IJobSchedule> Schedules => schedules.Value;

        public ScheduleProvider(IOptions<JobSettings> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            schedules = new Lazy<IEnumerable<IJobSchedule>>(() => GetSchedules());
        }

        public IEnumerable<IJobSchedule> GetSchedules()
        {
            var settings = options.Value;
            var result = new List<IJobSchedule>()
            {
                new JobSchedule()
                {
                    JobType = typeof(LogFileExamineJob),
                    CronExpression = settings.RepeatInterval
                }
            };

            return result;
        }
    }
}
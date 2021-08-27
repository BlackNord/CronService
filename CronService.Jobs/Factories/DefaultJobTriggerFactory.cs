using System;
using CronService.Jobs.Interfaces;
using Quartz;

namespace CronService.Jobs.Factories
{
    public class DefaultJobTriggerFactory : IJobTriggerFactory
    {
        public ITrigger Create(IJobSchedule jobSchedule)
        {
            if (jobSchedule == null)
            {
                throw new ArgumentNullException(nameof(jobSchedule));
            }

            var result = TriggerBuilder
                .Create()
                .WithIdentity(jobSchedule.JobType.Name)
                .WithCronSchedule(jobSchedule.CronExpression, x => x.InTimeZone(TimeZoneInfo.Local))
                .Build();

            return result;
        }
    }
}
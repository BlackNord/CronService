using CronService.Jobs.Factories.Interfaces;
using CronService.Jobs.Schedules.Intefaces;
using Quartz;
using System;

namespace CronService.Jobs.Factories
{
    public class DefaultJobDetailFactory : IJobDetailsFactory
    {
        public IJobDetail Create(IJobSchedule jobSchedule)
        {
            if (jobSchedule == null)
            {
                throw new ArgumentNullException(nameof(jobSchedule));
            }

            var result = JobBuilder
                .Create(jobSchedule.JobType)
                .WithIdentity(jobSchedule.JobType.Name)
                .WithDescription(jobSchedule.JobType.Name)
                .Build();

            return result;
        }
    }
}
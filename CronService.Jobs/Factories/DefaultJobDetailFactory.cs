using System;
using CronService.Jobs.Interfaces;
using Quartz;

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
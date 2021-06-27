using System;

namespace CronService.Jobs.Schedules.Interfaces
{
    public interface IJobSchedule
    {
        public Type JobType { get; }
        public string CronExpression { get; }
    }
}
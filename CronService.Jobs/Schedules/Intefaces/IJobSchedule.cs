using System;

namespace CronService.Jobs.Schedules.Intefaces
{
    public interface IJobSchedule
    {
        public Type JobType { get; }
        public string CronExpression { get; }
    }
}
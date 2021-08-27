using System;

namespace CronService.Jobs.Interfaces
{
    public interface IJobSchedule
    {
        public Type JobType { get; }
        public string CronExpression { get; }
    }
}
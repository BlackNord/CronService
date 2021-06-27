using System;
using CronService.Jobs.Schedules.Interfaces;

namespace CronService.Jobs.Schedules
{
    public class JobSchedule : IJobSchedule
    {
        public Type JobType { get; set; }
        public string CronExpression { get; set; }
    }
}
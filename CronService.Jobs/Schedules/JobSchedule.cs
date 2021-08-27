using System;
using CronService.Jobs.Interfaces;
using CronService.Jobs.Schedules.Intefaces;

namespace CronService.Jobs.Schedules
{
    public class JobSchedule : IJobSchedule
    {
        public Type JobType { get; set; }
        public string CronExpression { get; set; }
    }
}
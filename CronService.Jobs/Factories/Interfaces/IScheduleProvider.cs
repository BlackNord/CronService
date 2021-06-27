using System.Collections.Generic;
using CronService.Jobs.Schedules.Interfaces;

namespace CronService.Jobs.Factories.Interfaces
{
    public interface IScheduleProvider
    {
        IEnumerable<IJobSchedule> Schedules { get; }
    }
}
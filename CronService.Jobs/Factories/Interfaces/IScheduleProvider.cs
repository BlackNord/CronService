using System.Collections.Generic;
using CronService.Jobs.Schedules.Intefaces;

namespace CronService.Jobs.Factories.Interfaces
{
    public interface IScheduleProvider
    {
        IEnumerable<IJobSchedule> GetSchedules();
    }
}
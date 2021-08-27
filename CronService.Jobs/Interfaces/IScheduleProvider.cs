using System.Collections.Generic;

namespace CronService.Jobs.Interfaces
{
    public interface IScheduleProvider
    {
        IEnumerable<IJobSchedule> GetSchedules();
    }
}
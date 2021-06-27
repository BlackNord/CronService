using CronService.Jobs.Schedules.Interfaces;
using Quartz;

namespace CronService.Jobs.Factories.Interfaces
{
    public interface IJobDetailsFactory
    {
        IJobDetail Create(IJobSchedule jobSchedule);
    }
}
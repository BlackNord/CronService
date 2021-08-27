using CronService.Jobs.Schedules.Intefaces;
using Quartz;

namespace CronService.Jobs.Factories.Interfaces
{
    public interface IJobDetailsFactory
    {
        IJobDetail Create(IJobSchedule jobSchedule);
    }
}
using CronService.Jobs.Schedules.Interfaces;
using Quartz;

namespace CronService.Jobs.Factories.Interfaces
{
    public interface IJobTriggerFactory
    {
        ITrigger Create(IJobSchedule jobSchedule);
    }
}
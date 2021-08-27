using CronService.Jobs.Schedules.Intefaces;
using Quartz;

namespace CronService.Jobs.Factories.Interfaces
{
    public interface IJobTriggerFactory
    {
        ITrigger Create(IJobSchedule jobSchedule);
    }
}
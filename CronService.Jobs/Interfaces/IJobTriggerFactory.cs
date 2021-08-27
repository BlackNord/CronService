using Quartz;

namespace CronService.Jobs.Interfaces
{
    public interface IJobTriggerFactory
    {
        ITrigger Create(IJobSchedule jobSchedule);
    }
}
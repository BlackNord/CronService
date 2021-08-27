using Quartz;

namespace CronService.Jobs.Interfaces
{
    public interface IJobDetailsFactory
    {
        IJobDetail Create(IJobSchedule jobSchedule);
    }
}
using System;
using System.Threading.Tasks;
using Quartz;

namespace CronService.Jobs.Interfaces
{
    public interface ISchedulerContext : IAsyncDisposable
    {
        Task<IScheduler> Scheduler { get; }
    }
}
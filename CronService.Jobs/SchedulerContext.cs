using CronService.Jobs.Interfaces;
using Quartz;
using Quartz.Spi;
using System;
using System.Threading.Tasks;

namespace CronService.Jobs
{
    public sealed class SchedulerContext : ISchedulerContext
    {
        private readonly IJobFactory jobFactory;
        private readonly ISchedulerFactory schedulerFactory;
        private readonly Lazy<Task<IScheduler>> scheduler;

        public Task<IScheduler> Scheduler => scheduler.Value;

        public SchedulerContext(
            IJobFactory jobFactory,
            ISchedulerFactory schedulerFactory)
        {
            this.jobFactory = jobFactory ?? throw new ArgumentNullException(nameof(jobFactory));
            this.schedulerFactory = schedulerFactory ?? throw new ArgumentNullException(nameof(schedulerFactory));
            scheduler = new Lazy<Task<IScheduler>>(() => GetScheduler());
        }

        private async Task<IScheduler> GetScheduler()
        {
            var result = await schedulerFactory.GetScheduler();
            result.JobFactory = jobFactory;
            return result;
        }

        public async ValueTask DisposeAsync()
        {
            var disposable = await Scheduler;
            await disposable.Shutdown(true);
        }
    }
}
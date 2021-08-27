using CronService.Jobs.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CronService.Jobs
{
    public sealed class JobsHostedService : IHostedService
    {
        private readonly ISchedulerContext schedulerContext;
        private readonly IJobDetailsFactory jobDetailsFactory;
        private readonly IJobTriggerFactory jobTriggerFactory;
        private readonly IScheduleProvider scheduleProvider;

        public JobsHostedService(
            ISchedulerContext schedulerContext,
            IJobDetailsFactory jobDetailsFactory,
            IJobTriggerFactory jobTriggerFactory,
            IScheduleProvider scheduleProvider)
        {
            this.schedulerContext = schedulerContext ?? throw new ArgumentNullException(nameof(schedulerContext));
            this.jobDetailsFactory = jobDetailsFactory ?? throw new ArgumentNullException(nameof(jobDetailsFactory));
            this.jobTriggerFactory = jobTriggerFactory ?? throw new ArgumentNullException(nameof(jobTriggerFactory));
            this.scheduleProvider = scheduleProvider ?? throw new ArgumentNullException(nameof(scheduleProvider));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scheduler = await schedulerContext.Scheduler;

            foreach (var schedule in scheduleProvider.GetSchedules())
            {
                var detail = jobDetailsFactory.Create(schedule);
                var trigger = jobTriggerFactory.Create(schedule);

                await scheduler.ScheduleJob(detail, trigger, cancellationToken);
            }

            await scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await schedulerContext.DisposeAsync();
        }
    }
}

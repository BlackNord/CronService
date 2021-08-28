using CronService.Jobs.Factories.Interfaces;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CronService.Jobs
{
    public sealed class JobsHostedService : IHostedService
    {
        private readonly IJobFactory jobFactory;
        private readonly ISchedulerFactory schedulerFactory;
        private readonly IJobDetailsFactory jobDetailsFactory;
        private readonly IJobTriggerFactory jobTriggerFactory;
        private readonly IScheduleProvider scheduleProvider;

        private IScheduler Scheduler { get; set; }

        public JobsHostedService(
            IJobFactory jobFactory,
            ISchedulerFactory schedulerFactory,
            IJobDetailsFactory jobDetailsFactory,
            IJobTriggerFactory jobTriggerFactory,
            IScheduleProvider scheduleProvider)
        {
            this.jobFactory = jobFactory ?? throw new ArgumentNullException(nameof(jobFactory));
            this.schedulerFactory = schedulerFactory ?? throw new ArgumentNullException(nameof(schedulerFactory));
            this.jobDetailsFactory = jobDetailsFactory ?? throw new ArgumentNullException(nameof(jobDetailsFactory));
            this.jobTriggerFactory = jobTriggerFactory ?? throw new ArgumentNullException(nameof(jobTriggerFactory));
            this.scheduleProvider = scheduleProvider ?? throw new ArgumentNullException(nameof(scheduleProvider));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = jobFactory;

            foreach (var schedule in scheduleProvider.GetSchedules())
            {
                var detail = jobDetailsFactory.Create(schedule);
                var trigger = jobTriggerFactory.Create(schedule);

                await Scheduler.ScheduleJob(detail, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler.Shutdown(cancellationToken);
        }
    }
}

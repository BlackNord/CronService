using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CronService.Jobs.Factories.Interfaces;
using CronService.Jobs.Schedules.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Spi;

namespace CronService.Jobs
{
    public sealed class JobsHostedService : IHostedService
    {
        private readonly IJobFactory jobFactory;
        private readonly ISchedulerFactory schedulerFactory;
        private readonly IJobDetailsFactory jobDetailsFactory;
        private readonly IJobTriggerFactory jobTriggerFactory;
        private readonly IEnumerable<IJobSchedule> jobSchedules;
        private readonly ILogger<JobsHostedService> logger;

        private readonly Lazy<Task<IScheduler>> schedulerLazy;

        public Task<IScheduler> Scheduler => schedulerLazy.Value;

        public JobsHostedService(
            IJobFactory jobFactory,
            ISchedulerFactory schedulerFactory,
            IJobDetailsFactory jobDetailsFactory,
            IJobTriggerFactory jobTriggerFactory,
            IEnumerable<IJobSchedule> jobSchedules,
            ILogger<JobsHostedService> logger)
        {
            this.schedulerFactory = schedulerFactory ?? throw new ArgumentNullException(nameof(schedulerFactory));
            this.jobFactory = jobFactory ?? throw new ArgumentNullException(nameof(jobFactory));
            this.jobSchedules = jobSchedules ?? throw new ArgumentNullException(nameof(jobSchedules));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.jobDetailsFactory = jobDetailsFactory ?? throw new ArgumentNullException(nameof(jobDetailsFactory));
            this.jobTriggerFactory = jobTriggerFactory ?? throw new ArgumentNullException(nameof(jobTriggerFactory));

            schedulerLazy = new Lazy<Task<IScheduler>>(() => GetScheduler());
        }

        public async Task<IScheduler> GetScheduler()
        {
            var result = await schedulerFactory.GetScheduler();
            result.JobFactory = jobFactory;

            return result;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scheduler = await Scheduler;

            foreach (var schedule in jobSchedules)
            {
                var detail = jobDetailsFactory.Create(schedule);
                var trigger = jobTriggerFactory.Create(schedule);

                await scheduler.ScheduleJob(detail, trigger, cancellationToken);
            }

            await scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            var scheduler = await Scheduler;
            await scheduler.Shutdown(true, cancellationToken);
        }
    }
}

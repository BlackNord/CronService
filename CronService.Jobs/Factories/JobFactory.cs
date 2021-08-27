using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;

namespace CronService.Jobs.Factories
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public JobFactory(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            if (bundle == null)
            {
                throw new ArgumentNullException(nameof(bundle));
            }

            if (scheduler == null)
            {
                throw new ArgumentNullException(nameof(scheduler));
            }

            var jobType = bundle.JobDetail.JobType;

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var result = scope.ServiceProvider.GetRequiredService(jobType) as IJob;
                return result;
            }
        }

        public void ReturnJob(IJob job)
        {
            //NOTE: Leaved method empty because it uses in need for cleaning resources in jobs.
            //We don't need to do this
        }
    }
}
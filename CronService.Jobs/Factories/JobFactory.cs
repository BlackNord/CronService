using System;
using CronService.Jobs.Jobs.Base;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace CronService.Jobs.Factories
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider serviceProvider;

        public JobFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
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

            var result = serviceProvider.GetRequiredService<JobRunner>();
            return result;
        }

        public void ReturnJob(IJob job)
        {
            //NOTE: Leaved method empty because it uses in need for cleaning resources in jobs.
            //We don't need to do this
        }
    }
}
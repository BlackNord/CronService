using System;
using System.Threading.Tasks;
using CronService.Jobs.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace CronService.Jobs.Jobs.Base
{
    public class JobRunner : IJob
    {
        private readonly IServiceProvider serviceProvider;

        public JobRunner(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var jobType = context.JobDetail.JobType;
                var job = scope.ServiceProvider.GetJobOrThrow(jobType);
                await job.Execute(context);
            }
        }
    }
}
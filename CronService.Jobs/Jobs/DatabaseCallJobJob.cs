using System;
using Quartz;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CronService.Jobs.Jobs
{
    public sealed class DatabaseCallJobJob : IJob
    {
        private readonly ILogger<DatabaseCallJobJob> logger;

        public DatabaseCallJobJob(ILogger<DatabaseCallJobJob> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Execute(IJobExecutionContext context)
        {
            logger.LogInformation("1");
            return Task.CompletedTask;
        }
    }
}

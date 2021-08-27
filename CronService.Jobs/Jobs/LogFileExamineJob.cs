using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;

namespace CronService.Jobs.Jobs
{
    public sealed class LogFileExamineJob : IJob
    {
        private readonly ILogger<LogFileExamineJob> logger;

        public LogFileExamineJob(ILogger<LogFileExamineJob> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}

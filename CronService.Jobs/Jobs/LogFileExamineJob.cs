using System;
using Quartz;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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

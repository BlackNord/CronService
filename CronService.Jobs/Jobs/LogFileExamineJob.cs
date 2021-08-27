using CronService.Database.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;

namespace CronService.Jobs.Jobs
{
    public sealed class LogFileExamineJob : IJob
    {
        private readonly ILogFileProvider logFileProvider;
        private readonly IStoredProcedureExecutor storedProcedureExecutor;
        private readonly ILogger<LogFileExamineJob> logger;

        public LogFileExamineJob(
            ILogFileProvider logFileProvider,
            IStoredProcedureExecutor storedProcedureExecutor,
            ILogger<LogFileExamineJob> logger)
        {
            this.logFileProvider = logFileProvider ?? throw new ArgumentNullException(nameof(logFileProvider));
            this.storedProcedureExecutor = storedProcedureExecutor ?? throw new ArgumentNullException(nameof(storedProcedureExecutor));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Execute(IJobExecutionContext context)
        {

        }
    }
}

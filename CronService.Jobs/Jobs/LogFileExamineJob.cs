using CronService.Database.Services.Interfaces;
using CronService.Jobs.Infrastructure;
using CronService.Utils.Extensions;
using CronService.Utils.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using System;
using System.Threading.Tasks;

namespace CronService.Jobs.Jobs
{
    public sealed class LogFileExamineJob : IJob
    {
        private readonly ILogFileParser logFileParser;
        private readonly ILogFileProvider logFileProvider;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IStoredProcedureExecutor storedProcedureExecutor;
        private readonly IOptions<StoredProcedureCallSettings> options;
        private readonly ILogger<LogFileExamineJob> logger;

        public LogFileExamineJob(
            ILogFileParser logFileParser,
            ILogFileProvider logFileProvider,
            IDateTimeProvider dateTimeProvider,
            IStoredProcedureExecutor storedProcedureExecutor,
            IOptions<StoredProcedureCallSettings> options,
            ILogger<LogFileExamineJob> logger)
        {
            this.logFileParser = logFileParser ?? throw new ArgumentNullException(nameof(logFileParser));
            this.logFileProvider = logFileProvider ?? throw new ArgumentNullException(nameof(logFileProvider));
            this.dateTimeProvider = dateTimeProvider;
            this.storedProcedureExecutor = storedProcedureExecutor ?? throw new ArgumentNullException(nameof(storedProcedureExecutor));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var settings = options.Value;
            logger.LogDebug("job starting...");

            var logFileContent = await logFileProvider.GetLogFileContent();
            logger.LogDebug($"log file content: '{logFileContent}'");

            var latestLogFileTimestamp = logFileParser.GetLatestTimeStamp(logFileContent);
            logger.LogInformation($"latest timestamp in log file: '{latestLogFileTimestamp}'");

            var currentDate = dateTimeProvider.GetUtcNow();
            var difference = currentDate - latestLogFileTimestamp;

            logger.LogInformation($"difference: '{difference:g}'");
            logger.LogInformation($"difference for call (minutes): '{settings.DifferenceForCall.ToTimeSpan()}'");
            if (difference >= settings.DifferenceForCall.ToTimeSpan())
            {
                logger.LogInformation("running query...");
                await storedProcedureExecutor.ExecuteQuery();
            }
        }
    }
}

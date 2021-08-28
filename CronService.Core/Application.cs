using CronService.Database.Extensions;
using CronService.Database.Infrastructure;
using CronService.Jobs.Extensions;
using CronService.Jobs.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;
using CronService.Core.Constants;
using Microsoft.Extensions.Configuration;

namespace CronService.Core
{
    public class Application
    {
        private readonly Lazy<IHostBuilder> hostBuilder;

        public IHostBuilder HostBuilder => hostBuilder.Value;

        public Application()
        {
            hostBuilder = new Lazy<IHostBuilder>(() => CreateHostBuilder());
        }

        public async Task Run(string[] args)
        {
            await HostBuilder.RunConsoleAsync();
        }

        private IHostBuilder CreateHostBuilder()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(configurationBuilder =>
                {
                    configurationBuilder.AddEnvironmentVariables();
                    configurationBuilder.AddJsonFile(ConfigurationConstants.Files.AppSettings);
                    configurationBuilder.AddJsonFile(ConfigurationConstants.Files.Common);
                })
                .ConfigureServices((context, services)  =>
                {
                    services.AddOptions();
                    services.Configure<JobSettings>(context.Configuration.GetSection(nameof(JobSettings)));
                    services.Configure<DatabaseSettings>(context.Configuration.GetSection(nameof(DatabaseSettings)));
                    services.Configure<StoredProcedureCallSettings>(context.Configuration.GetSection(nameof(StoredProcedureCallSettings)));

                    services.AddJobs();
                    services.AddDatabase();
                })
                .UseSerilog((context, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
                });

            return builder;
        }
    }
}

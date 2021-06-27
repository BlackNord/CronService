using System;
using CronService.Database.Infrastructure;
using CronService.Jobs.Extensions;
using CronService.Jobs.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;
using CronService.Core.ConfigurationService;

namespace CronService.Core
{
    public class Application
    {
        private readonly Lazy<IConfiguration> configuration;
        private readonly Lazy<IHostBuilder> hostBuilder;

        public IConfiguration Configuration => configuration.Value;
        public IHostBuilder HostBuilder => hostBuilder.Value;

        public Application()
        {
            configuration = new Lazy<IConfiguration>(() => CreateConfiguration());
            hostBuilder = new Lazy<IHostBuilder>(() => CreateHostBuilder());
        }

        public async Task Run(string[] args)
        {
            await HostBuilder.RunConsoleAsync();
        }

        private IHostBuilder CreateHostBuilder()
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();
                    services.Configure<JobSettings>(Configuration.GetSection(nameof(JobSettings)));
                    services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));

                    services.AddJobs();
                })
                .UseSerilog((hostContext, config) =>
                {
                    config.ReadFrom.Configuration(Configuration);
                });

            return builder;
        }

        private IConfiguration CreateConfiguration()
        {
            var configProvider = new ConfigProvider();
            var config = configProvider.GetConfiguration();

            return config;
        }
    }
}

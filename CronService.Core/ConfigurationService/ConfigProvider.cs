using CronService.Core.ConfigurationService.Interfaces;
using CronService.Core.Constants;
using Microsoft.Extensions.Configuration;

namespace CronService.Core.ConfigurationService
{
    public class ConfigProvider : IConfigProvider
    {
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder();

            builder.AddEnvironmentVariables();
            builder.AddJsonFile(ConfigurationConstants.Files.AppSettings);
            builder.AddJsonFile(ConfigurationConstants.Files.Common);

            var result = builder.Build();
            return result;
        }
    }
}
using Microsoft.Extensions.Configuration;

namespace CronService.Core.ConfigurationService.Interfaces
{
    public interface IConfigProvider
    {
        IConfiguration GetConfiguration();
    }
}
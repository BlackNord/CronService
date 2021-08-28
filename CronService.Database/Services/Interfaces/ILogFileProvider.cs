using System.Threading.Tasks;

namespace CronService.Database.Services.Interfaces
{
    public interface ILogFileProvider
    {
        Task<string> GetLogFileContent();
    }
}
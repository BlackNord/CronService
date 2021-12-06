using System.Threading.Tasks;

namespace CronService.Database.Services.Interfaces
{
    public interface IStoredProcedureExecutor
    {
        Task ExecuteQuery();
    }
}

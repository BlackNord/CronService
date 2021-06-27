using System.Threading.Tasks;
using CronService.Core;

namespace CronService.Presentation
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var application = new Application();
            await application.Run(args);
        }
    }
}

using System;

namespace CronService.Utils.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTimeOffset GetUtcNow();
    }
}
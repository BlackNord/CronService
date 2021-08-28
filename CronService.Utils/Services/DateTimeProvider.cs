using System;
using CronService.Utils.Interfaces;

namespace CronService.Utils.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset GetUtcNow()
        {
            var result = DateTimeOffset.UtcNow;
            return result;
        }
    }
}
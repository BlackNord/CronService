using System;

namespace CronService.Utils.Extensions
{
    public static class TimeSpanParsingExtension
    {
        public static TimeSpan ToTimeSpan(this long source)
        {
            var result = TimeSpan.FromTicks(source);
            return result;
        }
    }
}
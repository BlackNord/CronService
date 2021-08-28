namespace CronService.Utils.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrWhitespace(this string source)
        {
            var result = string.IsNullOrWhiteSpace(source);
            return result;
        }
    }
}
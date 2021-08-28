namespace CronService.Database.Infrastructure
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string StoredProcedureName { get; set; }
        public string LogFilePath { get; set; }
    }
}
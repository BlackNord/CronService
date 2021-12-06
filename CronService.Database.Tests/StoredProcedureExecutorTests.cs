using System.Threading.Tasks;
using CronService.Database.Infrastructure;
using CronService.Database.Interfaces;
using CronService.Database.Services;
using Microsoft.Extensions.Options;
using Npgsql;
using NSubstitute;
using NUnit.Framework;

namespace CronService.Database.Tests
{
    /*
        create sequence test_id_seq;

        create table test (
            id integer PRIMARY KEY DEFAULT nextval('test_id_seq'),
            created_at timestamp 
        );

        create or replace procedure test_procedure()
        language plpgsql
        as $$
        begin
            INSERT INTO public.test(created_at)
            VALUES (CURRENT_TIMESTAMP);
            commit;
        end;$$
    */

    [TestFixture]
    public class StoredProcedureExecutorTests
    {
        private StoredProcedureExecutor storedProcedureExecutor;
        private IApplicationDatabaseContext applicationDatabaseContext;
        private IOptions<DatabaseSettings> options;

        [SetUp]
        public void Setup()
        {
            applicationDatabaseContext = Substitute.For<IApplicationDatabaseContext>();
            options = Substitute.For<IOptions<DatabaseSettings>>();

            storedProcedureExecutor = new StoredProcedureExecutor(options, applicationDatabaseContext);
        }

        [Test]
        public async Task ExecuteStoredProcedure_Should_CallStoredProcedure()
        {
            var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=test_database");
            connection.Open();
            var settings = new DatabaseSettings()
            {
                StoredProcedureName = "test_procedure",
                Query = "SELECT public.test_procedure();"
            };

            applicationDatabaseContext.Connection.Returns(connection);
            options.Value.Returns(settings);

            await storedProcedureExecutor.ExecuteQuery();

            await connection.CloseAsync();
            Assert.Pass();
        }
    }
}
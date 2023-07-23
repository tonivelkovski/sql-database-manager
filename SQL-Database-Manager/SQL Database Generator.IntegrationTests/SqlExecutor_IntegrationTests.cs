using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using SQL_Database_Generator.Services;
using Xunit;

namespace SQL_Database_Generator.IntegrationTests
{
    [Collection("Sequential")]
    public class SqlExecutor_IntegrationTests : IntegrationTest
    {
        [Fact]
        public void DeleteDatabase_GivenDatabase_ReturnsAllAttributesDeleted()
        {
            var testDatabaseRepository = new DatabaseTestRepository();
            var databaseRepository = new DatabaseRepository(TestDbConnector.Instance);
            var databasesViewService = new DatabasesViewService(databaseRepository);

            var database =
                new Database
                {
                    Username = "_daniel",
                    Name = "danielbaza",
                    Password = "password",
                    EmailSent = 0,
                    Note = "",
                    TeamNumber = "01_TM",
                };

            testDatabaseRepository.ExecuteCompleteCreateStatement(database);
            testDatabaseRepository.ExecuteCompleteDeleteStatement(database);

            var databases = databasesViewService.GetDatabases("2023");

            var isUserAndLoginDeleted = testDatabaseRepository.
                GetFromServer("sys.syslogins", database.Username);
            var databaseOnServerDeleted = testDatabaseRepository.
                GetFromServer("sys.databases", database.Name);
            var databaseInTableDeleted = databases.Count == 0;

            Assert.True(!isUserAndLoginDeleted && !databaseOnServerDeleted && databaseInTableDeleted);
        }

        [Fact]
        public void ExecuteCompleteCreateStatement_GivenDatabase_ReturnsAllAttributesAdded()
        {
           var testDatabaseRepository = new DatabaseTestRepository();
           var databaseRepository = new DatabaseRepository(TestDbConnector.Instance);
           var databasesViewService = new DatabasesViewService(databaseRepository);

            var database =
                new Database
                {
                    Username = "_daniel",
                    Name = "danielbaza",
                    Password = "password",
                    EmailSent = 0,
                    Note = "",
                    TeamNumber = "01_TM",
                };

            testDatabaseRepository.ExecuteCompleteCreateStatement(database);

            var databases = databasesViewService.GetDatabases("2023");

            var isUserAndLoginDeleted = testDatabaseRepository.
                GetFromServer("sys.syslogins", database.Username);
            var databaseOnServerDeleted = testDatabaseRepository.
                GetFromServer("sys.databases", database.Name);
            var databaseInTableDeleted = databases.Count == 0;

            Assert.True(isUserAndLoginDeleted && databaseOnServerDeleted && !databaseInTableDeleted);
        }

        [Fact]
        public void ExecuteCompleteArchiveStatement_GivenDatabase_ReturnsDatabaseArchived()
        {
            var testDatabaseRepository = new DatabaseTestRepository();
            var databaseRepository = new DatabaseRepository(TestDbConnector.Instance);
            var databasesViewService = new DatabasesViewService(databaseRepository);

            var database =
                new Database
                {
                    Username = "_daniel",
                    Name = "danielbaza",
                    Password = "password",
                    EmailSent = 0,
                    Archived = 0,
                    Note = "",
                    TeamNumber = "01_TM",
                };

            testDatabaseRepository.ExecuteCompleteCreateStatement(database);
            testDatabaseRepository.ExecuteCompleteArchiveStatement(database);

            var databases = databasesViewService.GetDatabases("2023");

            var databaseOnServerNotExist = testDatabaseRepository.
                GetFromServer("sys.databases", database.Name);
            var databaseInTableArchived = databases[0].Archived == 1;

            Assert.True(!databaseOnServerNotExist && databaseInTableArchived);
        }
    }
}

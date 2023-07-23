using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using SQL_Database_Generator.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SQL_Database_Generator.IntegrationTests
{
    [Collection("Sequential")]
    public class DatabasesViewService_IntegrationTests : IntegrationTest
    {
        [Fact]
        public void GetDatabases_GivenValidAcademicYear_ReturnsDatabases()
        {
            var testDatabaseRepository = new DatabaseTestRepository();
            var databaseRepository = new DatabaseRepository(TestDbConnector.Instance);
            var databasesViewService = new DatabasesViewService(databaseRepository);

            var databasesToBeCreated =
                new List<Database>
                {
                new Database
                {
                    Username = "_daniel",
                    Name = "danielbaza",
                    Password = "password",
                    EmailSent = 0,
                    Note = "",
                    TeamNumber = "01_TM",
                },
                new Database
                {
                    Username = "_toni",
                    Name = "tonibaza",
                    Password = "password",
                    EmailSent = 0,
                    Note = "",
                    TeamNumber = "02_TM",
                }
                };

            databasesToBeCreated.ForEach(database => testDatabaseRepository.ExecuteCompleteCreateStatement(database));

            var databasesDatabasesTable = databasesViewService.GetDatabases("2023");
            var serverContainsDatabases = databasesToBeCreated.
                Select(database => testDatabaseRepository.
                GetFromServer("sys.databases", database.Name)).ToList();

            Assert.NotEmpty(databasesDatabasesTable);
            Assert.True(serverContainsDatabases.All(result => result));
            Assert.Equal(databasesToBeCreated.Count, databasesDatabasesTable.Count);

            for (int i = 0; i < databasesToBeCreated.Count; i++)
            {
                Assert.Equal(databasesToBeCreated[i].TeamNumber, databasesDatabasesTable[i].TeamNumber);
                Assert.Equal(databasesToBeCreated[i].Name, databasesDatabasesTable[i].Name);
                Assert.Equal(databasesToBeCreated[i].Username, databasesDatabasesTable[i].Username);
                Assert.Equal(databasesToBeCreated[i].Password, databasesDatabasesTable[i].Password);
                Assert.Equal(databasesToBeCreated[i].Note, databasesDatabasesTable[i].Note);
                Assert.Equal(databasesToBeCreated[i].EmailSent, databasesDatabasesTable[i].EmailSent);
            }
        }

        [Fact]
        public void GetDatabases_GivenNonValidAcademicYear_ReturnsEmptyDatabaseList()
        {
            var testDatabaseRepository = new DatabaseTestRepository();
            var databaseRepository = new DatabaseRepository(TestDbConnector.Instance);
            var databasesViewService = new DatabasesViewService(databaseRepository);

            var databaseToBeCreated =
                new Database
                {
                    Username = "_daniel",
                    Name = "danielbaza",
                    Password = "password",
                    EmailSent = 0,
                    Note = "",
                    TeamNumber = "01_TM",
                };

            testDatabaseRepository.ExecuteCompleteCreateStatement(databaseToBeCreated);

            var databases = databasesViewService.GetDatabases("2150");

            Assert.Empty(databases);
        }
    }
}

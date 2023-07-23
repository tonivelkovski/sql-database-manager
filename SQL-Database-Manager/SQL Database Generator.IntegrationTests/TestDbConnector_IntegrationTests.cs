using System.Data.SqlClient;
using Xunit;

namespace SQL_Database_Generator.IntegrationTests
{
    [Collection("Sequential")]
    public class TestDbConnector_IntegrationTests : IntegrationTest
    {
        [Fact]
        public void TestDbConnector_GivenConnectionToServerIsEstablished_ConnectorIsNotNull()
        {
            var dbConnector = TestDbConnector.Instance;

            Assert.NotNull(dbConnector);
        }

        [Fact]
        public void TestDbConnector_GivenConnectionToServerIsEstablished_StudentskeBazeDatabaseExists()
        {
            var dbConnector = TestDbConnector.Instance;

            dbConnector.ExecuteQuery("USE [StudentskeBaze];");
        }

        [Fact]
        public void TestDbConnector_GivenConnectionToServerIsEstablished_DatabasesTableExists()
        {
            CheckDatabaseTableExists("Databases");
        }

        [Fact]
        public void TestDbConnector_GivenConnectionToServerIsEstablished_MailSettingsTableExists()
        {
            CheckDatabaseTableExists("MailSettings");
        }

        [Fact]
        public void TestDbConnector_GivenConnectionToServerIsEstablished_MailSettingsTableIsLockedToOneRowOnly()
        {
            var dbConnector = TestDbConnector.Instance;

            void act()
            {
                dbConnector.ExecuteQuery("INSERT INTO StudentskeBaze.dbo.MailSettings DEFAULT VALUES;");
            }

            Assert.Throws<SqlException>(act);
        }

        private void CheckDatabaseTableExists(string tableName)
        {
            var dbConnector = TestDbConnector.Instance;

            dbConnector.ExecuteQuery($"SELECT * FROM StudentskeBaze.dbo.{tableName};");
        }
    }
}
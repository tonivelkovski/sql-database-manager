using FakeItEasy;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class DatabaseRepository_UnitTests
    {
        [Fact]
        public void GetDatabases_GivenDataReaderIsEmpty_ReturnsEmptyDatabasesList()
        {
            var dbConnector = A.Dummy<IDbConnector>();
            var dataReader = A.Fake<DbDataReader>();
            var databaseRepository = new DatabaseRepository(dbConnector);

            A.CallTo(() => dataReader.Read()).Returns(false);

            var databases = databaseRepository.GetDatabases("2023");

            Assert.Empty(databases);
        }

        [Fact]
        public void GetDatabases_GivenAcademicYear_ReturnsCorrectDatabasesProperties()
        {
            var expectedDatabases = CreateDatabases();
            var dbConnector = A.Fake<IDbConnector>();
            var dataReader = A.Fake<DbDataReader>();
            var databaseRepository = new DatabaseRepository(dbConnector);

            var currentRow = -1;
            A.CallTo(() => dataReader.Read())
                .ReturnsLazily(() =>
                {
                    currentRow++;
                    return currentRow < expectedDatabases.Count;
                });

            A.CallTo(() => dataReader["TeamNumber"])
                .ReturnsLazily(() => expectedDatabases[currentRow].TeamNumber);

            A.CallTo(() => dataReader["Name"])
                .ReturnsLazily(() => expectedDatabases[currentRow].Name);

            A.CallTo(() => dataReader["Username"])
                .ReturnsLazily(() => expectedDatabases[currentRow].Username);

            A.CallTo(() => dataReader["Password"])
                .ReturnsLazily(() => expectedDatabases[currentRow].Password);

            A.CallTo(() => dataReader["CreationDate"])
                .ReturnsLazily(() => expectedDatabases[currentRow].CreationDate);

            A.CallTo(() => dataReader["Note"])
                .ReturnsLazily(() => expectedDatabases[currentRow].Note);

            A.CallTo(() => dataReader["EmailSent"])
                .ReturnsLazily(() => expectedDatabases[currentRow].EmailSent);

            A.CallTo(() => dataReader["Archived"])
           .ReturnsLazily(() => expectedDatabases[currentRow].Archived);

            A.CallTo(() => dataReader["ContactEmail"])
                .ReturnsLazily(() => expectedDatabases[currentRow].ContactEmail);

            A.CallTo(() => dbConnector.GetDataReader(A<string>.Ignored)).Returns(dataReader);

            var actualDatabases = databaseRepository.GetDatabases("2023");

            Assert.Equal(expectedDatabases.Count, actualDatabases.Count);

            for (int i = 0; i < expectedDatabases.Count; i++)
            {
                Assert.Equal(expectedDatabases[i].TeamNumber, actualDatabases[i].TeamNumber);
                Assert.Equal(expectedDatabases[i].Name, actualDatabases[i].Name);
                Assert.Equal(expectedDatabases[i].Username, actualDatabases[i].Username);
                Assert.Equal(expectedDatabases[i].Password, actualDatabases[i].Password);
                Assert.Equal(expectedDatabases[i].CreationDate, actualDatabases[i].CreationDate);
                Assert.Equal(expectedDatabases[i].Note, actualDatabases[i].Note);
                Assert.Equal(expectedDatabases[i].EmailSent, actualDatabases[i].EmailSent);
                Assert.Equal(expectedDatabases[i].ContactEmail, actualDatabases[i].ContactEmail);
            }
        }

        [Fact]
        public void CheckIfExists_GivenDatabaseExists_ReturnsTrue()
        {
            var dbConnector = A.Fake<IDbConnector>();
            var databaseRepository = new DatabaseRepository(dbConnector);
            var dataReader = A.Fake<DbDataReader>();
            var databaseName = "SampleDatabase";

            A.CallTo(() => dbConnector.GetDataReader(A<string>._)).Returns(dataReader);
            A.CallTo(() => dataReader.HasRows).Returns(true);

            var result = databaseRepository.CheckIfExists(databaseName);

            Assert.True(result);
        }

        [Fact]
        public void CheckIfExists_GivenDatabaseDoesNotExists_ReturnsFalse()
        {
            var dbConnector = A.Fake<IDbConnector>();
            var databaseRepository = new DatabaseRepository(dbConnector);
            var dataReader = A.Fake<DbDataReader>();
            var databaseName = "SampleDatabase";

            A.CallTo(() => dbConnector.GetDataReader(A<string>._)).Returns(dataReader);
            A.CallTo(() => dataReader.HasRows).Returns(false);

            var result = databaseRepository.CheckIfExists(databaseName);

            Assert.False(result);
        }

        private List<Database> CreateDatabases() =>
            new List<Database> {
                new Database
                {
                    Username = "_daniel",
                    Name = "danielbaza",
                    Password = "password",
                    ContactEmail= "danielemail",
                    CreationDate = DateTime.Parse("2023-06-01 14:30:00"),
                    EmailSent = 0,
                    Archived = 0,
                    Note = "",
                    TeamNumber = "01_TM",
                },
                new Database
                {
                    Username = "_toni",
                    Name = "tonibaza",
                    Password = "password",
                    ContactEmail= "toniemail",
                    CreationDate = DateTime.Parse("2023-06-01 14:30:00"),
                    EmailSent = 0,
                    Archived = 0,
                    Note = "",
                    TeamNumber = "02_TM",
                },
            };
    }
}

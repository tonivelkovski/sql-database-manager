using FakeItEasy;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using SQL_Database_Generator.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class DatabasesViewService_UnitTests
    {
        [Fact]
        public void GetDatabases_GivenTheAcademicYearIsNull_ThrowsArgumentNullException()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            string academicYearNull = null;

            void actNull() => databasesViewService.GetDatabases(academicYearNull);

            Assert.Throws<ArgumentNullException>(actNull);
        }

        [Fact]
        public void GetDatabases_GivenTheAcademicYearIsEmpty_ThrowsArgumentNullException()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var academicYearEmpty = string.Empty;

            void actEmpty() => databasesViewService.GetDatabases(academicYearEmpty);

            Assert.Throws<ArgumentNullException>(actEmpty);
        }

        [Fact]
        public void GetDatabases_GivenValidAcademicYear_ReturnsDatabases()
        {
            var databaseRepository = A.Fake<IDatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var academicYear = "2023";
            var expectedDatabases = CreateDatabases();

            A.CallTo(() => databaseRepository.GetDatabases(academicYear)).Returns(expectedDatabases);

            var actualDatabases = databasesViewService.GetDatabases(academicYear);

            Assert.Equal(expectedDatabases, actualDatabases);
        }

        [Fact]
        public void GetDatabases_GivenTheAcademicYearIsNotValid_ThrowsArgumentNullException()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var academicYearNotValid = "non valid year";

            void actEmpty() => databasesViewService.GetDatabases(academicYearNotValid);

            Assert.Throws<ArgumentNullException>(actEmpty);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenValidName_MatchesExactMatch()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = CreateDatabases();

            var filteredDatabasesByName = databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, "danielbaza");

            Assert.Equal(new List<Database> { actualDatabases[0] }, filteredDatabasesByName);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenValidName_MatchesPartialMatch()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = CreateDatabases();

            var filteredDatabasesByNameMatch = databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, "baza");

            Assert.Equal(actualDatabases, filteredDatabasesByNameMatch);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenValidContactEmail_MatchesExactMatch()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = CreateDatabases();

            var filteredDatabasesByContactEmail = databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, "danielemail");

            Assert.Equal(new List<Database> { actualDatabases[0] }, filteredDatabasesByContactEmail);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenValidContactEmail_MatchesPartialMatch()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = CreateDatabases();

            var filteredDatabasesByContactEmailMatch = databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, "email");

            Assert.Equal(actualDatabases, filteredDatabasesByContactEmailMatch);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenEmptySearchText_ReturnsAllDatabases()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = CreateDatabases();

            var filteredDatabasesEmptyString = databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, string.Empty);

            Assert.Equal(actualDatabases, filteredDatabasesEmptyString);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenSearchTextIsNull_ThrowsArgumentNullException()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = CreateDatabases();

            void actEmpty() => databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, null);

            Assert.Throws<ArgumentNullException>(actEmpty);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenDatabasesListIsNull_ThrowsArgumentNullException()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);

            void actEmpty() => databasesViewService.FilterDatabasesBasedOnSearchText(null, "random");

            Assert.Throws<ArgumentNullException>(actEmpty);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenDatabasesListContainsNullElements_ThrowsArgumentNullException()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = CreateDatabasesWithNull();

            var filteredDatabases = databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, "danielbaza");

            Assert.Single(filteredDatabases);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenDatabasesListContainsNullElementsProperties_ThrowsArgumentNullException()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = new List<Database> {
                new Database
                {
                    Username = "_daniel",
                    Name = "danielbaza",
                    Password = "password",
                    ContactEmail= null,
                    CreationDate = DateTime.Parse("2023-06-01 14:30:00"),
                    EmailSent = 0,
                    Note = "",
                    TeamNumber = "01_TM",
                } };

            void actEmpty() => databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, "random");

            Assert.Throws<ArgumentNullException>(actEmpty);
        }
        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenNameAndContactEmailDoesNotExist_ReturnsEmptyList()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = CreateDatabases();

            var filteredDatabasesContactEmailNameDoesNotExist = databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, "not existing");

            Assert.Equal(new List<Database> { }, filteredDatabasesContactEmailNameDoesNotExist);
        }

        [Fact]
        public void FilterDatabasesBasedOnSearchText_GivenDatabasesListIsEmpty_ReturnsNoDatabases()
        {
            var databaseRepository = A.Dummy<DatabaseRepository>();
            var databasesViewService = new DatabasesViewService(databaseRepository);
            var actualDatabases = new List<Database> { };

            var filteredDatabasesEmptyString = databasesViewService.FilterDatabasesBasedOnSearchText(actualDatabases, "random");

            Assert.Equal(actualDatabases, filteredDatabasesEmptyString);
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
                    Note = "",
                    TeamNumber = "02_TM",
                },
                new Database
                {
                    Username = "_tin",
                    Name = "tinbaza",
                    Password = "password",
                    ContactEmail= "tinemail",
                    CreationDate = DateTime.Parse("2022-06-01 14:30:00"),
                    EmailSent = 0,
                    Note = "",
                    TeamNumber = "03_TM",
                }
            };

        private List<Database> CreateDatabasesWithNull() =>
            new List<Database> {
                new Database
                {
                    Username = "_daniel",
                    Name = "danielbaza",
                    Password = "password",
                    ContactEmail= "danielemail",
                    CreationDate = DateTime.Parse("2023-06-01 14:30:00"),
                    EmailSent = 0,
                    Note = "",
                    TeamNumber = "01_TM",
                },
                null,
                null
            };
    }
}

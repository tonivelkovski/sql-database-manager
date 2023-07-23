using SQL_Database_Generator.Extensions;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using System;
using System.Collections.Generic;

namespace SQL_Database_Generator.Services
{
    public class DatabasesViewService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public DatabasesViewService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public List<Database> GetDatabases(string academicYear) =>
            !int.TryParse(academicYear, out _)
                ? throw new ArgumentNullException(nameof(academicYear))
                : _databaseRepository.GetDatabases(academicYear);

        public List<Database> FilterDatabasesBasedOnSearchText(List<Database> unfilteredDatabases,
            string searchText)
        {
            unfilteredDatabases.ThrowIfNull(nameof(unfilteredDatabases));
            searchText.ThrowIfNull(nameof(searchText));

            return unfilteredDatabases.FindAll(database =>
            {
                if (database is null)
                    return false;

                database.Name.ThrowIfNull(database.Name);
                database.ContactEmail.ThrowIfNull(database.ContactEmail);

                return database.Name.Contains(searchText) || database.ContactEmail.Contains(searchText);
            });
        }
    }
}

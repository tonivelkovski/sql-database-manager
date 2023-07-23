using SQL_Database_Generator.Models;
using System.Collections.Generic;
using System.Linq;

namespace SQL_Database_Generator.Utils
{
    public static class DataImporter
    {
        public static List<Database> Import(string[] students) =>
            students.Select(db => CreateDatabaseEntry(db)).Where(entry => entry != null).ToList();

        private static Database CreateDatabaseEntry(string db)
        {
            string[] dbParts = db.Split(';');

            if (dbParts.Length != 4 || dbParts.Any(part => string.IsNullOrEmpty(part)))
            {
                return null;
            }
            string username = dbParts[2].Split('@')[0];

            return new Database
            {
                TeamNumber = username,
                Name = EntryGenerator.GenerateName(string.Empty, username, "_DB"),
                Username = username,
                Password = EntryGenerator.GeneratePassword()
            };
        }
    }
}

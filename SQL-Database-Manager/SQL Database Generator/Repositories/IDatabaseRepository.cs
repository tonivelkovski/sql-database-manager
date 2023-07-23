using SQL_Database_Generator.Models;
using System.Collections.Generic;

namespace SQL_Database_Generator.Repositories
{
    public interface IDatabaseRepository
    {
        List<Database> GetDatabases(string academicYear);
    }
}

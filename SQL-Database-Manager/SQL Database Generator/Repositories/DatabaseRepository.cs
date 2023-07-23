using SQL_Database_Generator.Models;
using SQL_Database_Generator.Utils;
using System;
using System.Collections.Generic;

namespace SQL_Database_Generator.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IDbConnector _dbConnector;
        private readonly SqlGenerator _sqlGenerator;

        public DatabaseRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
            _sqlGenerator = new SqlGenerator();
        }

        public List<Database> GetDatabases(string academicYear)
        {
            List<Database> list = new List<Database>();
            string sql = _sqlGenerator.CreateGetDatabasesByAcademicYearStatement(academicYear);
            var dr = _dbConnector.GetDataReader(sql);

            while (dr.Read())
            {
                list.Add(new Database
                {
                    TeamNumber = dr["TeamNumber"].ToString(),
                    Name = dr["Name"].ToString(),
                    Username = dr["Username"].ToString(),
                    Password = dr["Password"].ToString(),
                    CreationDate = Convert.ToDateTime(dr["CreationDate"]),
                    Note = dr["Note"].ToString(),
                    EmailSent = int.Parse(dr["EmailSent"].ToString()),
                    Archived = int.Parse(dr["Archived"].ToString()),
                    ContactEmail = dr["ContactEmail"].ToString()
                });
            }

            dr.Close();

            return list;
        }

        public bool CheckIfExists(string databaseName)
        {
            string sql = _sqlGenerator.CreateGetDatabasesByNameStatement(databaseName);
            var dr = _dbConnector.GetDataReader(sql);
            bool exists = dr.HasRows;
            dr.Close();

            return exists;
        }
    }
}

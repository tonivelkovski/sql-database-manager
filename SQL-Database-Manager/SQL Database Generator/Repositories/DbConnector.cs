using SQL_Database_Generator.Extensions;
using System.Data.Common;
using System.Data.SqlClient;

namespace SQL_Database_Generator.Repositories
{
    public class DbConnector : IDbConnector
    {
        private static DbConnector _instance;
        private readonly SqlConnection _connection;

        private DbConnector()
        {
            _connection = new SqlConnection(GetConnectionString());
            _connection.Open();
        }

        public static string Server { get; set; }
        public static string AdminUsername { get; set; }
        public static string AdminPassword { get; set; }

        public static DbConnector Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbConnector();
                }
                return _instance;
            }
        }

        public DbDataReader GetDataReader(string sqlQuery) =>
            new SqlCommand(sqlQuery, _connection).ExecuteReader();

        public int ExecuteQuery(string sqlQuery) =>
            new SqlCommand(sqlQuery, _connection).ExecuteNonQuery();

        private string GetConnectionString()
        {
            Server.ThrowIfNullOrWhiteSpace(nameof(Server));
            AdminUsername.ThrowIfNullOrWhiteSpace(nameof(AdminUsername));
            AdminPassword.ThrowIfNullOrWhiteSpace(nameof(AdminPassword));

            return "Server=" + Server + ";User Id=" + AdminUsername + ";Password=" + AdminPassword + ";";
        }
    }
}

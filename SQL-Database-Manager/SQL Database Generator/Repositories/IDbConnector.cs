using System.Data.Common;

namespace SQL_Database_Generator.Repositories
{
    public interface IDbConnector
    {
        DbDataReader GetDataReader(string sqlQuery);
        int ExecuteQuery(string sqlQuery);
    }
}

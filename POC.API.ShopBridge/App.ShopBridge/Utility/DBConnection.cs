using System.Data.SqlClient;

namespace App.ShopBridge.Utility
{
    public interface ISqlDBConnection
    {
        SqlConnection GetConnection(string connectionString);
    }

    public class SqlDBConnection : ISqlDBConnection
    {
        public SqlConnection GetConnection(string connectionString) => new SqlConnection(connectionString);
    }
}

using System.Data.SqlClient;

namespace MsSql.Schema.Queries
{
    public class DatabasesQuery : MsSql.Client.SqlQuery<string>
    {
        protected override string Mapping(SqlDataReader reader)
        {
            return reader["name"].ToString();
        }
    }
}
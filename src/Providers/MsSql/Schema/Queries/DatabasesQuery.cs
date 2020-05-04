using System.Data.SqlClient;
using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class DatabasesQuery : MsSql.Client.SqlQuery<DatabaseInfo>
    {
        protected override DatabaseInfo Mapping(SqlDataReader reader)
        {
            return new DatabaseInfo
            {
                Name = reader["name"].ToString()
            };
        }
    }
}
using System.Data.SqlClient;
using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class DatabasesQuery : MsSql.Client.SqlQuery<DataBaseInfo>
    {
        protected override DataBaseInfo Mapping(SqlDataReader reader)
        {
            return new DataBaseInfo
            {
                Name = reader["name"].ToString()
            };
        }
    }
}
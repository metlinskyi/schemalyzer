using MsSql.Client;

namespace MsSql.Schema.Queries
{
    public class DatabasesQuery : SqlQuery<string>
    {
        protected override string Mapping(ISqlDataReader reader)
        {
            return reader["name"].ToString();
        }
    }
}
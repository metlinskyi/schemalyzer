using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class DatabasesQuery : MsSql.Client.SqlQuery<DataBaseInfo>
    {
        public DatabasesQuery()
        {
        }
    }
}
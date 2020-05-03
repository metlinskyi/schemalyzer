using System.Data.SqlClient;
using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class ColumnsQuery : MsSql.Client.SqlQuery<ColumnInfo>
    {
        public ColumnsQuery(TableInfo table)
        {
        }

        protected override ColumnInfo Mapping(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}
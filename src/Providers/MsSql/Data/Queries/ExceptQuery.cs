using System.Data.SqlClient;
using Client.Schema.Information;

namespace MsSql.Data.Queries
{
    public class ExceptQuery : MsSql.Client.SqlQuery<string>
    {
        public ExceptQuery(ColumnInfo fp, ColumnInfo pk)
        {
        }
        protected override string Mapping(SqlDataReader reader)
        {
            return reader[0].ToString();
        }
    }
}
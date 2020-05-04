using System.Data.SqlClient;
using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class ColumnsQuery : MsSql.Client.SqlQuery<ColumnInfo>
    {
        private readonly TableInfo _table;
        public ColumnsQuery(TableInfo table)
        {
            _table = table;

            var tab = _table.Name.Split('.');
            Parameter("@database", _table.Database.Name);
            Parameter("@schema", tab[0]);
            Parameter("@table", tab[1]);

            Repalce("/*DATABASE_NAME.*/", table.Database.Name + ".");
        }
        protected override ColumnInfo Mapping(SqlDataReader reader)
        {
            return new ColumnInfo
            {
                Table = _table,
                Name = reader["COLUMN_NAME"].ToString()
            };
        }
    }
}
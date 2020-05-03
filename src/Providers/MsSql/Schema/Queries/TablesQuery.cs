using System.Data.SqlClient;
using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class TablesQuery : MsSql.Client.SqlQuery<TableInfo>
    {
        public TablesQuery(DataBaseInfo db)
        {
            Parametr("/*DATABASE_NAME.*/", db.Name + ".");
        }

        protected override TableInfo Mapping(SqlDataReader reader)
        {
            return new TableInfo
            {
                Name = reader["TABLE_NAME"].ToString()
            };
        }
    }
}
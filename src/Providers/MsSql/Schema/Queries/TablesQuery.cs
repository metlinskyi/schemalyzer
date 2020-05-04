using System.Data.SqlClient;
using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class TablesQuery : MsSql.Client.SqlQuery<TableInfo>
    {
        private readonly DatabaseInfo _database;
        public TablesQuery(DatabaseInfo database)
        {
            _database = database;
            
            Repalce("/*DATABASE_NAME.*/", _database.Name + ".");
        }
        protected override TableInfo Mapping(SqlDataReader reader)
        {
            return new TableInfo
            {
                Database = _database,
                Name = $"{reader["TABLE_SCHEMA"]}.{reader["TABLE_NAME"]}"
            };
        }
    }
}
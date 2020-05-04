using System.Collections.Generic;
using Client.Schema;
using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    using Queries;
    public class SchemaProvider : ISchemaProvider
    {
        private readonly Client.SqlClient _client;
        public SchemaProvider(string connectionString)
        {
            _client = new MsSql.Client.SqlClient(connectionString);
        }
        public IEnumerable<DatabaseInfo> Databases()
        {
            foreach(var db in _client.Execute(new DatabasesQuery()))
            {
                db.Tables = _client.Execute(new TablesQuery(db));

                foreach(var table in db.Tables)
                {
                    table.Columns = _client.Execute(new ColumnsQuery(table));        
                }

                yield return db;
            }
        }
    }
}
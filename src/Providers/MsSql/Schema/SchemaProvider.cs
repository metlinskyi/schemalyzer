using System.Collections.Generic;
using System.Linq;
using Client.Schema;
using Client.Schema.Information;

namespace MsSql.Schema
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
            foreach(var db in _client.Execute(new DatabasesQuery()).Select(x => new DatabaseInfo{ Name = x }))
            {
                var schema = _client.Execute(new SchemaQuery(db.Name)).ToArray();

                foreach(var table in db.Tables)
                {
;        
                }

                yield return db;
            }
        }
    }
}
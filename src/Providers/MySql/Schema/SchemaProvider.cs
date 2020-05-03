using System.Collections.Generic;
using Client.Schema;
using Client.Schema.Information;

namespace MySql.Schema
{
    public class SchemaProvider : ISchemaProvider
    {
        private readonly Client.SqlClient _client;
            
        public SchemaProvider()
        {
        }

        public IEnumerable<DataBaseInfo> Databases()
        {
            throw new System.NotImplementedException();
        }
    }
}
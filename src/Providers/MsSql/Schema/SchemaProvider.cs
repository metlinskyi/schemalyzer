using System.Collections.Generic;
using Client.Schema;
using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class SchemaProvider : ISchemaProvider
    {
        public IEnumerable<DataBaseInfo> Databases()
        {
            throw new System.NotImplementedException();
        }
    }
}
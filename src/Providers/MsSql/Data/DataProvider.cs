using System.Collections.Generic;
using Client.Data;
using Client.Schema.Information;

namespace MsSql.Data
{
    using Queries;
    public class DataProvider : IDataProvider
    {
        private readonly Client.SqlClient _client;
        public DataProvider(string connectionString)
        {
            _client = new MsSql.Client.SqlClient(connectionString);
        }
        public bool IsIntersect(ColumnInfo fk, ColumnInfo pk)
        {
            _client.Execute(new IntersectQuery(fk, pk));

            return false;
        }
    }
}
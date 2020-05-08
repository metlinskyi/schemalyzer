using System.Linq;
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
            return _client.Execute(new ExceptQuery(fk, pk)).Count() == 0;
        }
    }
}
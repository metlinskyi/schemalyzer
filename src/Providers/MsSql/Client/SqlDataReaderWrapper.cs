using System.Data.SqlClient;

namespace MsSql.Client
{
    public class SqlDataReaderWrapper : ISqlDataReader
    {
        private readonly SqlDataReader sqlDataReader;
        public SqlDataReaderWrapper(SqlDataReader sqlDataReader)
        {
            this.sqlDataReader = sqlDataReader;
        }
        public object this[string name]
        {
            get => this.sqlDataReader[name];
        }
        public object this[int index]
        {
            get => this.sqlDataReader[index];
        }
    }
}
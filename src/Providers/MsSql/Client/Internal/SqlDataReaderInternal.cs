using System;
using System.Data.SqlClient;

namespace MsSql.Client.Internal
{
    internal class SqlDataReaderInternal : ISqlDataReader
    {
        private readonly SqlDataReader sqlDataReader;
        public SqlDataReaderInternal(SqlDataReader sqlDataReader)
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
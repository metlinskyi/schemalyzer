using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace MsSql.Client
{
    public class SqlClient : IDisposable 
    {
        private readonly SqlConnection connection;
        private readonly ISqlQueryReader queryReader;
        private bool disposed = false;
        public SqlClient(string connectionString) : this(connectionString, new SqlQueryReader())
        {
        }
        public SqlClient(string connectionString, ISqlQueryReader queryReader)
        {            
            this.connection = new SqlConnection(connectionString);
            this.queryReader = queryReader;
        }
        public TQuery Execute<TQuery>(TQuery query) where TQuery : SqlQuery
        {
            // gets the text of query
            query.Query = this.queryReader.Read<TQuery>();
            // gets the sql command and parametrs
            var command = new SqlCommand(query.Query, connection);
            foreach(var p in query.Parameters ?? Enumerable.Empty<KeyValuePair<string,object>>())
            {
                command.Parameters.Add(new SqlParameter(p.Key, p.Value));
            }
            // execute
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                using (var reader = command.ExecuteReader())
                {
                    var wrapper = new SqlDataReaderWrapper(reader);
                    while (reader.Read())
                    {
                        query.Binding(wrapper);
                    }
                }
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                throw new Exception(query.Query, e);
            }
            return query;
        }
        #region IDisposable
        public void Dispose()
        { 
            Dispose(true);
            GC.SuppressFinalize(this);           
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return; 
            
            if (disposing) 
            {
                connection.Dispose();
            }
            disposed = true;
        }
        ~SqlClient()
        {
            Dispose(false);
        }
        #endregion

    }
}

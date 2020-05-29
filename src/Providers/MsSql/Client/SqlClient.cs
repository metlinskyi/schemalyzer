using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace MsSql.Client
{
    using Internal;
    public class SqlClient : IDisposable 
    {
        private readonly SqlConnection connection;
        private readonly ISqlQueryReader reader;
        private readonly ISqlDataBinder mapper;
        private bool disposed = false;
        private SqlClient()
        {
        }
        public SqlClient(string connectionString) : this(connectionString, Internal<ISqlQueryReader>.Instance, Internal<ISqlDataBinder>.Instance)
        {
        }
        public SqlClient(string connectionString, ISqlQueryReader reader, ISqlDataBinder mapper) : this()
        {            
            this.connection = new SqlConnection(connectionString);
            this.reader = reader;
            this.mapper = mapper;
        }
        public TQuery Execute<TQuery>(TQuery query) where TQuery : SqlQuery
        {
            var isEnumerable = query is IEnumerable;
            // gets the text of query
            query.Query = this.reader.Read<TQuery>();
            // gets the sql command and parametrs
            var command = new SqlCommand(query.Query, connection);
            foreach(var p in query.Parameters ?? Enumerable.Empty<KeyValuePair<string,object>>())
            {
                command.Parameters.Add(new SqlParameter(p.Key, p.Value));
            }
            query.Initializing(mapper);
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                // execute
                if(isEnumerable)
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var wrapper = new SqlDataReaderInternal(reader);
                        while (reader.Read())
                        {
                            query.Binding(wrapper);
                            query.Count++;
                        }
                    }
                }
                else 
                {
                   query.Count = command.ExecuteNonQuery();
                }
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                throw new Exception($"{query.Query}{System.Environment.NewLine}", e);
            }
            query.Ending();
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
            {
                return; 
            }
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
using System;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace MsSql.Client
{
    public class SqlClient : IDisposable 
    {
        private readonly SqlConnection _connection;
        bool _disposed = false;
        public SqlClient(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public TQuery Execute<TQuery>(TQuery query) where TQuery : SqlQuery
        {
            // gets the text of query
            var type = typeof(TQuery).GetTypeInfo();
            query.Query = ReadManifestData(type.Assembly, type.Name.Replace("Query", ".sql"));
            // gets the sql command and parametrs
            var command = new SqlCommand(query.Query, _connection);
            foreach(var p in query.Parameters ?? Enumerable.Empty<KeyValuePair<string,object>>())
            {
                command.Parameters.Add(new SqlParameter(p.Key, p.Value));
            }
            // execute
            if(_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        query.Binding(reader);
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
            if (_disposed)
                return; 
            
            if (disposing) 
            {
                _connection.Dispose();
            }

            _disposed = true;
        }
        ~SqlClient()
        {
            Dispose(false);
        }
        #endregion
        private static string ReadManifestData(Assembly assembly, string filename)
        {
            var resourceName = assembly
                .GetManifestResourceNames()
                .First(x => x.EndsWith(filename, StringComparison.CurrentCultureIgnoreCase));

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("Could not load manifest resource stream.");
                }
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

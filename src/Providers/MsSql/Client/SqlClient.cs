using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq;
using System.IO;

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
            var command = new SqlCommand(null, _connection);
            _connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}:{reader[1]} ${reader[2]}");
                }
            }

            return default;
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
            
            if (disposing) {
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
            /*
                        var type = typeof(TSource);
            var assembly = type.GetTypeInfo().Assembly;

            _query = ReadManifestData(type, $"{type.Name.}.sql");
            */
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

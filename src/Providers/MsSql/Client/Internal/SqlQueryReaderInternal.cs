using System;
using System.Collections.Concurrent;

namespace MsSql.Client.Internal
{
    internal class SqlQueryReaderInternal : ConcurrentDictionary<Type, string>, ISqlQueryReader, IInternalService
    {
        private readonly IManifestResourceReader manifestResourceReader;
        public SqlQueryReaderInternal() : this(new ManifestResourceReader())
        {
        }
        public SqlQueryReaderInternal(IManifestResourceReader manifestResourceReader)
        {
            this.manifestResourceReader = manifestResourceReader;
        }
        public string Read<TQuery>() where TQuery : SqlQuery
        {
            return GetOrAdd(typeof(TQuery), Add);
        }
        private string Add(Type type)
        {
            return manifestResourceReader.Read(type.Assembly, type.Name.Replace("Query", ".sql"));
        }
    }
}
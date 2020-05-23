using System.Reflection;

namespace MsSql.Client
{
    public class SqlQueryReader : ISqlQueryReader
    {
        private readonly IManifestResourceReader manifestResourceReader;
        public SqlQueryReader() : this(new ManifestResourceReader())
        {
        }
        public SqlQueryReader(IManifestResourceReader manifestResourceReader)
        {
            this.manifestResourceReader = manifestResourceReader;
        }
        public string Read<TQuery>() where TQuery : SqlQuery
        {
            var type = typeof(TQuery).GetTypeInfo();
            return manifestResourceReader.Read(type.Assembly, type.Name.Replace("Query", ".sql"));
        }
    }
}
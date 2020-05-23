using System.Reflection;

namespace MsSql.Client
{
    public interface IManifestResourceReader
    {
        string Read(Assembly assembly, string filename);
    }
}
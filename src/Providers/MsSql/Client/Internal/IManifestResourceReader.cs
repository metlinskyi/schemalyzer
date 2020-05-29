using System.Reflection;

namespace MsSql.Client
{
    internal interface IManifestResourceReader
    {
        string Read(Assembly assembly, string filename);
    }
}
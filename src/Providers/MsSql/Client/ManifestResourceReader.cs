using System;
using System.Reflection;
using System.Linq;
using System.IO;

namespace MsSql.Client
{
    public class ManifestResourceReader : IManifestResourceReader
    {
        public string Read(Assembly assembly, string filename)
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
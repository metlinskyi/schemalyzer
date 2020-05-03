using System;
using System.Runtime.Loader;
using System.Linq;
using System.IO;
using Client.Schema;
using Client.Data;

namespace Console
{
    using Helpers;

    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(currentDirectory, args.FirstOrDefault()));

            var schemaProvider = assembly.CreateInstanceFor<ISchemaProvider>();
            var dataProvider = assembly.CreateInstanceFor<IDataProvider>();
            
            var app = new App.Schemalyzer(schemaProvider, dataProvider);

            app.Run();
        }
    }
}

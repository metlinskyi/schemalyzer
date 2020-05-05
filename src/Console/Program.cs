using System;
using System.Runtime.Loader;
using System.Runtime;
using System.Reflection;
using System.Linq;
using System.IO;
using Client.Schema;
using Client.Data;
using static System.Console;

namespace Console
{
    using Helpers;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                WriteLine("The arguments not found.");
                return;
            }

            var provider = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), args.FirstOrDefault()));
            if(!provider.Exists)
            {
                WriteLine($"The file {provider.FullName} not found.");
                return;      
            }

            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(provider.FullName);

            foreach(var filename in provider.Directory.GetFiles("*.dll").Select(x=>x.FullName))
            {
                if(AssemblyLoadContext.Default.Assemblies.Any(x=>x.GetName().FullName == AssemblyName.GetAssemblyName(filename).FullName))
                {
                    continue;
                }
                try
                {
                    //AssemblyLoadContext.Default.LoadFromAssemblyPath(filename);
                }
                catch
                {
                }
            }

            var schemaProvider = assembly.CreateInstanceFor<ISchemaProvider>(args.Skip(1).ToArray());
            var dataProvider = assembly.CreateInstanceFor<IDataProvider>(args.Skip(1).ToArray());
            
            var app = new App.Schemalyzer(schemaProvider, dataProvider);

            app.Run();
        }
    }
}

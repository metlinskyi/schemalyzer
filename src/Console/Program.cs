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
        static App.Schemalyzer.Status currentStatus;
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ERROR("The arguments not found.");
                return;
            }

            var provider = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), args.FirstOrDefault()));
            if(!provider.Exists)
            {
                ERROR($"The file {provider.FullName} not found.");
                return;      
            }

            Write($"Initializing...");

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

            OK();

            var schemaProvider = assembly.CreateInstanceFor<ISchemaProvider>(args.Skip(1).ToArray());
            var dataProvider = assembly.CreateInstanceFor<IDataProvider>(args.Skip(1).ToArray());
            
            new App.Schemalyzer(schemaProvider, dataProvider).Run(Output);
        }

        static void Output(App.Schemalyzer.Status status, byte percentage)
        {
            if(currentStatus != status)
            {
                currentStatus = status;
                WriteLine();
                Write($"{status.ToString()}...");
            }
            if(percentage == 100)
            {
                OK();
            }
        }
        static void OK(string value = "OK", bool newline = false)
        {
            ForegroundColor = ConsoleColor.Green;
            Write(value);
            ForegroundColor = ConsoleColor.White;
            if(newline)
            {
                WriteLine();
            }
        }
        static void ERROR(string value = "ERROR", bool newline = false)
        {
            ForegroundColor = ConsoleColor.Red;
            Write(value);
            ForegroundColor = ConsoleColor.White;
            if(newline)
            {
                WriteLine();
            }
        }
    }
}

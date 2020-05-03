using System;
using System.Linq;
using System.Reflection;

namespace Console.Helpers
{
    public static class AssemblyHelper
    {
        public static T CreateInstanceFor<T>(this Assembly assembly, params object[] args)
        {
            var type = assembly.GetTypes()
                .Where(p => typeof(T).IsAssignableFrom(p))
                .FirstOrDefault();

            if(type == null)
            {
                throw new Exception($"The types are assignable from {typeof(T).Name} not foud.");
            }    

            return (T)Activator.CreateInstance(type, args);
        }
    }
}
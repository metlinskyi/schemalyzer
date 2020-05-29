using System;
using System.Collections.Generic;

namespace MsSql.Client.Internal
{
    internal class Internal
    {
        protected static IDictionary<Type, Func<IInternalService>> factory = new Dictionary<Type, Func<IInternalService>>
        {
            { typeof(ISqlQueryReader), () => new SqlQueryReaderInternal() },
            { typeof(ISqlDataBinder), () => new SqlDataMapperInternal() }
        };
    }
    internal class Internal<T> : Internal
    {        
        private static Lazy<T> instance = new Lazy<T>(() => (T)factory[typeof(T)](), true);
        public static T Instance => instance.Value;
    }
}
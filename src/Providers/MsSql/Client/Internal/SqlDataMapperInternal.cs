using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace MsSql.Client.Internal
{
    internal class SqlDataMapperInternal : ConcurrentDictionary<Type, IDictionary<string, PropertyInfo>>, ISqlDataBinder, IInternalService
    {
        public SqlDataMapperInternal()
        {
        }
        public Client.ISqlDataBinder<TEntity> For<TEntity>(Action<ISqlRowMapper<TEntity>> action)
        {
            var mapper = new SqlRowMapperInternal<TEntity>(GetOrAdd(typeof(TEntity), Add), action);

            return new SqlDataBinderInternal<TEntity>(mapper.Activator, mapper.Binders);
        }
        private IDictionary<string, PropertyInfo> Add(Type type)
        {
            return type
                .GetProperties()
                .Where(x => x.CanWrite)
                .ToDictionary(x => x.Name, x=>x);
        }
    }
}
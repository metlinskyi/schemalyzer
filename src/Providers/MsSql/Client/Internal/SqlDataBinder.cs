using System;
using System.Collections.Generic;
using System.Linq;

namespace MsSql.Client.Internal
{
    using Mapping;
    internal class SqlDataBinderInternal<TEntity> : ISqlDataBinder<TEntity>
    {
        private Func<TEntity> activator;
        private readonly IEnumerable<ColumnBinder> binders;
        public SqlDataBinderInternal(Func<TEntity> activator, IEnumerable<ColumnBinder> binders) 
        {
            this.activator = activator;
            this.binders = binders as ColumnBinder[] ?? binders.ToArray();
        }
        public TEntity GetEntity(ISqlDataReader reader)
        {
            object obj = activator();
            foreach(var binder in binders)
            {
                var value = binder.Column.GetValue(reader);
                binder.SetValue(ref obj, value);
            }
            return (TEntity) obj;
        }
    }
}
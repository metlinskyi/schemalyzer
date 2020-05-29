using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MsSql.Client.Internal
{
    using Mapping;
    internal class SqlRowMapperInternal
    {
        protected SqlRowMapperInternal(IDictionary<string, PropertyInfo> properties)
        {
            Properties = properties;
            Binders = new List<ColumnBinder>(properties.Count);
        }
        protected IDictionary<string, PropertyInfo> Properties { get; private set; }
        public IList<ColumnBinder> Binders { get; private set; }
    }
    internal class SqlRowMapperInternal<TEntity> : SqlRowMapperInternal, ISqlRowMapper<TEntity>
    {
        public Func<TEntity> Activator { get; private set; }
        public SqlRowMapperInternal(IDictionary<string, PropertyInfo> properties, Action<ISqlRowMapper<TEntity>> action) : base(properties)
        {
            Activator = () => default(TEntity);
            action(this);
        }
        public void For(Func<TEntity> activator)
        {
            Activator = activator;
        }
        public ISqlColumnBinder For<TField>(System.Linq.Expressions.Expression<System.Func<TEntity, TField>> expression)
        {
            PropertyBinder binder = null;

            if(expression.Parameters.Count == 0)
            {
                throw new Exception();
            }

            var param = (ParameterExpression)expression.Parameters[0];  
            
            var name = expression.Body
                .ToString()
                .Replace(param.Name, string.Empty)
                .Trim('.');

            if(Properties.TryGetValue(name, out PropertyInfo property))
            {
                binder = Binders
                    .OfType<PropertyBinder>()
                    .SingleOrDefault(x => x.Property == property);

                if(binder == null)
                {
                    Binders.Add(binder = new PropertyBinder(property)
                    {
                        Column = ColumnInfo.Get(name)
                    });
                }
            }

            if(binder == null)
            {
                throw new Exception();
            }

            return binder;
        }
        public ISqlColumnBinder For()
        {
            var binder = Binders
                .OfType<ValueBinder>()
                .SingleOrDefault();
 
            if(binder == null)
            {
                Binders.Add(binder = new ValueBinder(typeof(TEntity))
                {   
                    Column = ColumnInfo.Get(0) // a first column by default 
                });
            }

            return binder;
        }
    }
}
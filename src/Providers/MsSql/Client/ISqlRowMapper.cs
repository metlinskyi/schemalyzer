using System;
using System.Linq.Expressions;

namespace MsSql.Client
{
    using Internal;
    public interface ISqlRowMapper<TEntity>
    {
        void For(Func<TEntity> activator);
        ISqlColumnBinder For<TField>(Expression<Func<TEntity, TField>> entity);
        ISqlColumnBinder For();
    }
}
using System;

namespace MsSql.Client
{
    public interface ISqlDataBinder
    {
        ISqlDataBinder<TEntity> For<TEntity>(Action<ISqlRowMapper<TEntity>> action);
    }
    public interface ISqlDataBinder<TEntity>
    {
        TEntity GetEntity(ISqlDataReader reader);
    }
}
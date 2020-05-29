using MsSql.Client;

namespace MsSql.Schema.Queries
{
    public class RoutineQuery : SqlQuery<RoutineEntity>
    {
        public RoutineQuery(string database)
        {
            Repalce("[master]", database.ToDatabaseName());
        }
        protected override void Mapping(ISqlRowMapper<RoutineEntity> mapper)
        {
            mapper.For(() => new RoutineEntity());
            mapper.For(x => x.ROUTINE_SCHEMA);
            mapper.For(x => x.ROUTINE_NAME);
            mapper.For(x => x.ROUTINE_TYPE);
        }
    }
}
using MsSql.Client;

namespace MsSql.Schema.Queries
{
    public class RoutineQuery : SqlQuery<RoutineEntity>
    {
        public RoutineQuery(string database)
        {
            Repalce("[master]", database.ToDatabaseName());
        }
        protected override RoutineEntity Mapping(ISqlDataReader reader)
        {
            return new RoutineEntity
            {
                ROUTINE_SCHEMA= reader["ROUTINE_SCHEMA"].ToString(),
                ROUTINE_NAME = reader["ROUTINE_NAME"].ToString(),
                ROUTINE_TYPE = reader["ROUTINE_TYPE"].ToString()
            };
        }
    }
}
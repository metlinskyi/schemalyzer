using System.Data.SqlClient;

namespace MsSql.Schema.Queries
{
    public class RoutineQuery : MsSql.Client.SqlQuery<RoutineEntity>
    {
        public RoutineQuery(string database)
        {
            Repalce("[master]", $"[{database}]");
        }
        protected override RoutineEntity Mapping(SqlDataReader reader)
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
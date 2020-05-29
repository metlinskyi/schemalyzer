using MsSql.Client;
using Client.Schema.Information;

namespace MsSql.Data.Queries
{
    public class ExceptQuery : SqlQuery<int>
    {
        public ExceptQuery(ColumnInfo fk, ColumnInfo pk)
        {
            Repalce("[A]",          fk.GetDatabaseName());
            Repalce("[FK_TABLE]",   fk.GetEntityName());
            Repalce("[FK_COLUMN]",  fk.GetName());
            Repalce("[B]",          pk.GetDatabaseName());
            Repalce("[PK_TABLE]",   pk.GetEntityName());
            Repalce("[PK_COLUMN]",  pk.GetName());
        }
        protected override void Mapping(ISqlRowMapper<int> mapper)
        {
            mapper.For().From(0);
        }
    }
}
using MsSql.Client;
using Client.Schema.Information;

namespace MsSql.Data.Queries
{
    public class ExceptQuery : SqlQuery<string>
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
        protected override string Mapping(ISqlDataReader reader)
        {
            return reader[0].ToString();
        }
    }
}
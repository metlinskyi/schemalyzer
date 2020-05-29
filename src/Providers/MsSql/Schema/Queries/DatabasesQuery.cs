using MsSql.Client;

namespace MsSql.Schema.Queries
{
    public class DatabasesQuery : SqlQuery<string>
    {
        protected override void Mapping(ISqlRowMapper<string> mapper)
        {
            mapper.For().From("name");
        }
    }
}
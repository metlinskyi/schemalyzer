using MsSql.Client;

namespace MsSql.Schema.Queries
{
    public class ReferencesQuery : SqlQuery<ReferencesEntity>
    {
        public ReferencesQuery(string name)
        {
            Parameter("referencing_entity_name", name);
        }
        protected override ReferencesEntity Mapping(ISqlDataReader reader)
        {
            return new ReferencesEntity
            {

            };
        }
    }
}
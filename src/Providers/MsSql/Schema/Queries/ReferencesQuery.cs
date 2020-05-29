using MsSql.Client;

namespace MsSql.Schema.Queries
{
    public class ReferencesQuery : SqlQuery<ReferencesEntity>
    {
        public ReferencesQuery(string database, string name)
        {
            Repalce("[master]", database.ToDatabaseName());
            Parameter("referencing_entity_name", name);
        }
        protected override void Mapping(ISqlRowMapper<ReferencesEntity> mapper)
        {
            mapper.For(() => new ReferencesEntity());
            mapper.For(x => x.referenced_schema_name);
            mapper.For(x => x.referenced_entity_name);
            mapper.For(x => x.referenced_minor_name);
            mapper.For(x => x.referenced_class_desc);  
            mapper.For(x => x.type_desc);          
        }
    }
}
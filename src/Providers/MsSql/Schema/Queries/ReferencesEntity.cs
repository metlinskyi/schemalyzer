namespace MsSql.Schema.Queries
{
    public class ReferencesEntity
    {
        public string referenced_schema_name { get; set; }
        public string referenced_entity_name { get; set; }
        public string referenced_minor_name { get; set; }
        public string referenced_class_desc { get; set; }
        public string type_desc { get; set; }      
    }
}
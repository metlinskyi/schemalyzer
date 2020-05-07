namespace MsSql.Schema.Queries
{
    public class SchemaEntity
    {
        public string TABLE_SCHEMA { get; set; }  
        public string TABLE_NAME { get; set; }  
        public string TABLE_TYPE { get; set; }
        public string COLUMN_NAME { get; set; } 
        public bool IS_NULLABLE { get; set; } 
        public string DATA_TYPE { get; set; } 
        public string CHARACTER_MAXIMUM_LENGTH { get; set; } 
        public string CONSTRAINT_TYPE { get; set; } 
        public string CONSTRAINT_NAME { get; set; } 
    }
}
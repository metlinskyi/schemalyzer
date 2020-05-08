namespace Client.Schema.Information
{
    using System.Collections.Generic;
    public abstract class EntityInfo : InformationSchema
    {
        public DatabaseInfo Database { get; set; } 
        public IEnumerable<ColumnInfo> Columns { get; set; } 
        
        public override string ToString()
        {
            return Name;
        }
    }
}
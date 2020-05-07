namespace Client.Schema.Information
{
    using System.Collections.Generic;
    public class ViewInfo : InformationSchema
    {
        public DatabaseInfo Database { get; set; } 
        public IEnumerable<ColumnInfo> Columns { get; set; } 
    }
}
namespace Client.Schema.Information
{
    using System.Collections.Generic;

    public class TableInfo : InformationSchema
    {
       public IEnumerable<ColumnInfo> Columns { get; set; } 
    }
}
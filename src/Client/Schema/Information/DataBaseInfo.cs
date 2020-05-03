namespace Client.Schema.Information
{
    using System.Collections.Generic;
    
    public class DataBaseInfo : InformationSchema
    {
        IEnumerable<TableInfo> Tables { get; set; }

        IEnumerable<string> Scripts { get; set; }
    }
}
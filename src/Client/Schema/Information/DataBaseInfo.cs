namespace Client.Schema.Information
{
    using System.Collections.Generic;
    public class DataBaseInfo : InformationSchema
    {
        public IEnumerable<TableInfo> Tables { get; set; }
        public IEnumerable<string> Scripts { get; set; }
    }
}
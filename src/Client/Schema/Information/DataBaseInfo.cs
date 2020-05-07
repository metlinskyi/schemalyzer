namespace Client.Schema.Information
{
    using System.Collections.Generic;
    public class DatabaseInfo : InformationSchema
    {
        public IEnumerable<TableInfo> Tables { get; set; }
        public IEnumerable<TableInfo> Views { get; set; }
        public IEnumerable<string> Scripts { get; set; }
    }
}
namespace Client.Schema.Information
{
    using System.Collections.Generic;
    public class DatabaseInfo : InformationSchema
    {
        public IEnumerable<TableInfo> Tables { get; set; }
        public IEnumerable<ViewInfo> Views { get; set; }
        public IEnumerable<RoutineInfo> Routines { get; set; }
    }
}
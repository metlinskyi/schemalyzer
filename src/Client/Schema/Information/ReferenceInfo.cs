using System.Collections.Generic;

namespace Client.Schema.Information
{
    public class ReferenceInfo
    {
        public EntityInfo Entity { get; set; }
        public IEnumerable<ColumnInfo> Columns { get; set; }
    }
}
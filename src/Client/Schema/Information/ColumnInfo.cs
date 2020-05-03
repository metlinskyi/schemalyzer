using System.Collections.Generic;

namespace Client.Schema.Information
{
    public class ColumnInfo : InformationSchema
    {
        public TableInfo Table { get; set; }

        public DataTypeInfo DataType { get; set; }
    }
}
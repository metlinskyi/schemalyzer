using System.Collections.Generic;

namespace Client.Schema.Information
{
    public interface IColumnInfo : IInformationSchema
    {
        ITableInfo Table { get; }

        IDataTypeInfo DataType { get; }
    }
}
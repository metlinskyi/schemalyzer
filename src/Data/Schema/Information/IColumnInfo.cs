using System.Collections.Generic;

namespace Data.Schema.Information
{
    public interface IColumnInfo : IInformationSchema
    {
        ITableInfo Table { get; }

        IDataTypeInfo DataType { get; }
    }
}
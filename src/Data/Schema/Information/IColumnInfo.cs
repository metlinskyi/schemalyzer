using System.Collections.Generic;

namespace Data.Schema.Information
{
    public interface IColumnInfo : IInformationSchema
    {
        IDataTypeInfo DataType { get; }
    }
}
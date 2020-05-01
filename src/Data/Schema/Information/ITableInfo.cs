using System.Collections.Generic;

namespace Data.Schema.Information
{
    public interface ITableInfo : IInformationSchema
    {
       IEnumerable<IColumnInfo> Columns { get; } 
    }
}
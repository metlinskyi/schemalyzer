using System.Collections.Generic;

namespace Client.Schema.Information
{
    public interface ITableInfo : IInformationSchema
    {
       IEnumerable<IColumnInfo> Columns { get; } 
    }
}
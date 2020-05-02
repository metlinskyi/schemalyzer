using System.Collections.Generic;

namespace Client.Schema.Information
{
    public interface IDataBaseInfo : IInformationSchema
    {
        IEnumerable<ITableInfo> Tables { get; }

        IEnumerable<string> Scripts { get; }
    }
}
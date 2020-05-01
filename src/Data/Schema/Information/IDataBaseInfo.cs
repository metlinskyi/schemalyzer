using System.Collections.Generic;

namespace Data.Schema.Information
{
    public interface IDataBaseInfo : IInformationSchema
    {
        IEnumerable<ITableInfo> Tables { get; }

        IEnumerable<string> Views { get; }

        IEnumerable<string> Synonyms { get; }

        IEnumerable<string> Programmability { get; }
    }
}
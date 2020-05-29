namespace Client.Schema
{
    using System.Collections.Generic;
    using Information;
    public interface IReferences
    {
        IEnumerable<ReferenceInfo> References { get; }
    }
}
using System.Collections.Generic;

namespace Client.Schema.Information
{
    public class ViewInfo : EntityInfo, IReferences, ISource
    {
        public string Source { get; set; }
        public IEnumerable<ReferenceInfo> References => throw new System.NotImplementedException();
    }
}
using System.Collections.Generic;

namespace Client.Schema.Information
{
    public class RoutineInfo : InformationSchema, ISource
    {
        public string Source { get; set; }
        public IEnumerable<ReferenceInfo> References { get; set; }
    }
}
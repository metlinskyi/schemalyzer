using System.Collections.Generic;
using Client.Schema.Information;
using System.Linq;

namespace App
{
    public class Querylyzer 
    {
        public IEnumerable<IRelationInfo> Parse(string query)
        {
            return Enumerable.Empty<IRelationInfo>();
        }
    }
}
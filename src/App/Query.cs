using System.Collections.Generic;

namespace App
{
    public class Query
    {
        public Query Subquery { get; set; }
        public string Select { get; set; } 
        public string From { get; set; }        
        public IList<string> Join { get; set; }
        public string Where { get; set; }
    }
}
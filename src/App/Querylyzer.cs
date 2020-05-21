using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Client.Schema.Information;

namespace App
{
    public class Querylyzer 
    {
        private const string pattern = @"SELECT(?=\s+)|FROM(?=\s+)|JOIN(?=\s+)|WHERE(?=\s+)";
        private readonly Regex _regex;
        public Querylyzer()
        {
            _regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }
        public IEnumerable<RelationInfo> Parse(ViewInfo x)
        {
            return Parse(x.Source).ToArray();
        }
        public IEnumerable<RelationInfo> Parse(RoutineInfo x)
        {
            return Parse(x.Source).ToArray();
        }
        public IEnumerable<RelationInfo> Parse(string x)
        {
            foreach(var match in _regex.Matches(x))
            {
                yield return new RelationInfo();
            }
        }
    }
}
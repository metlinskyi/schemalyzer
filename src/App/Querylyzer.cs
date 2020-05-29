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
        public IEnumerable<RelationInfo> Parse(string source)
        {
            int x,y;
            string substring;
            Match match;
            Query query = null;

            var matches = _regex.Matches(source);

            for(int i = 0; i < matches.Count; i++)
            {
                /*
                match = matches[i];
                x = match.Index;
                y = i > matches.Count ? source.Length : matches[i+1].Index;

                substring = source.Substring(x,y);

                switch(match.Value.ToUpper())
                {
                    case Keywords.Select:
                    {
                        query = query ?? new Query();
                        query.Select = substring;
                    }
                    break;
                    case Keywords.From:
                    {
                        query.From = substring;
                    }
                    break;
                    case Keywords.Join:
                    {
                        query.Join = query.Join ?? new List<string>();
                        query.Join.Add(substring);
                    }
                    break;
                    case Keywords.Where:
                    {
                        query.Where = substring;
                    }
                    break;
                }
                */
                yield return new RelationInfo();
            }
        }
    }
}
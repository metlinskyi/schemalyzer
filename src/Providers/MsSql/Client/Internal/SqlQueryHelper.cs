using System;
using System.Text;

namespace MsSql.Client.Internal
{
    internal static class SqlQueryHelper
    {
        private const string DEBUG_BEGIN = "#DEBUG";
        private const string DEBUG_END = "#END";
        public static StringBuilder GetTemplate(string value)
        {
            var template = new StringBuilder(value);
            var begin = value.IndexOf(DEBUG_BEGIN);
            if(begin > -1)
            {
                var end = value.IndexOf(DEBUG_END) + DEBUG_END.Length;
                if(end > begin)
                {
                    template.Remove(begin, end - begin);
                }
            }
            return template;
        }     
    }
}
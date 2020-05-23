using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace MsSql.Client
{
    public abstract class SqlQuery
    {
        private const string DEBUG_BEGIN = "#DEBUG";
        private const string DEBUG_END = "#END";     
        private string _query;
        private IDictionary<string, string> _replaces;
        private IDictionary<string, object> _parameters;
        public IDictionary<string, object> Parameters => _parameters;
        public String Query 
        { 
            get
            {
                return _query;
            } 
            set
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
                foreach(var p in _replaces ?? Enumerable.Empty<KeyValuePair<string,string>>())
                {
                    template.Replace(p.Key, p.Value);
                }
                _query = template.ToString();
            } 
        }
        protected SqlQuery()
        {
            _replaces = new Dictionary<string, string>(); 
        }
        protected virtual void Repalce(string name, string value)
        {
            _replaces = _replaces ?? new Dictionary<string, string>();
            _replaces.Add(name, value);
        }
        protected virtual void Parameter<TValue>(string name, TValue value)
        {
            _parameters = _parameters ?? new Dictionary<string, object>();
            _parameters.Add(name, value);
        }
        public abstract void Binding(ISqlDataReader reader);
    }

    public abstract class SqlQuery<TResult> : SqlQuery, IEnumerable<TResult> where TResult : class
    {
        private readonly IList<TResult> _result;
        protected SqlQuery()
        {
            _result = new List<TResult>();
        }
        #region IEnumerator<>
        public IEnumerator<TResult> GetEnumerator()
        {
            return _result.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _result.GetEnumerator();
        }
        #endregion
        public override void Binding(ISqlDataReader reader)
        {
            _result.Add(Mapping(reader));
        }
        protected abstract TResult Mapping(ISqlDataReader reader);
    }
}
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Text;

namespace MsSql.Client
{
    public abstract class SqlQuery
    {
        private string _query;
        private IDictionary<string, string> _parametrs;
        public String Query 
        { 
            get
            {
                return _query;
            } 
            set
            {
                var template = new StringBuilder(value);
                foreach(var p in _parametrs)
                {
                    template.Replace(p.Key, p.Value);
                }
                _query = template.ToString();
            } 
        }
        protected SqlQuery()
        {
            _parametrs = new Dictionary<string, string>(); 
        }
        public virtual void Binding(SqlDataReader reader)
        {
        }
        protected virtual void Parametr<TValue>(string name, TValue value)
        {
            _parametrs.Add(name, value.ToString());
        }
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
        public override void Binding(SqlDataReader reader)
        {
            _result.Add(Mapping(reader));
        }
        protected abstract TResult Mapping(SqlDataReader reader);
    }
}
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace MsSql.Client
{
    using Internal;
    public abstract class SqlQuery
    { 
        private string query;
        private IDictionary<string, string> replaces;
        private IDictionary<string, object> parameters;
        internal IDictionary<string, object> Parameters => parameters;
        public string Query 
        { 
            get
            {
                return query;
            } 
            internal set
            {
                var template = SqlQueryHelper.GetTemplate(value);
                foreach(var p in replaces ?? Enumerable.Empty<KeyValuePair<string,string>>())
                {
                    template.Replace(p.Key, p.Value);
                }
                query = template.ToString();
            } 
        }
        public int Count { get; internal set; }
        protected SqlQuery()
        {
        }
        protected virtual void Repalce(string name, string value)
        {
            replaces = replaces ?? new Dictionary<string, string>();
            replaces.Add(name, value);
        }
        protected virtual void Parameter<TValue>(string name, TValue value)
        {
            parameters =  parameters ?? new Dictionary<string, object>();
            parameters.Add(name, value);
        }
        internal abstract void Initializing(ISqlDataBinder mapper);
        internal abstract void Binding(ISqlDataReader reader);
        internal abstract void Ending();
    }

    public abstract class SqlQuery<TEntity> : SqlQuery, IEnumerable<TEntity> 
    {
        private readonly IList<TEntity> entities;
        private ISqlDataBinder<TEntity> binder;
        protected SqlQuery()
        {
            entities = new List<TEntity>();
        }
        #region IEnumerator<>
        public IEnumerator<TEntity> GetEnumerator()
        {
            return entities.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }
        #endregion
        internal override void Initializing(ISqlDataBinder binder)
        {
            this.binder = binder.For<TEntity>(Mapping);
        }
        internal override void Binding(ISqlDataReader reader)
        {
            entities.Add(binder.GetEntity(reader));
        }
        internal override void Ending()
        {
            Result(this);
        }
        protected virtual void Result(IEnumerable<TEntity> entities)
        {
        }
        protected abstract void Mapping(ISqlRowMapper<TEntity> mapper);
    }
}
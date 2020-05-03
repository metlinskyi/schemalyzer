namespace MsSql.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public abstract class SqlQuery : IEnumerable
    {
        public String Query { get; protected set; }

        protected SqlQuery()
        {
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class SqlQuery<TResult> : SqlQuery, IEnumerable<TResult> where TResult : class
    {
        protected SqlQuery()
        {
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
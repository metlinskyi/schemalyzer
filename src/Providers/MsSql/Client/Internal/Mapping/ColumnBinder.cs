using System;

namespace MsSql.Client.Internal.Mapping
{
    internal abstract class ColumnBinder : ISqlColumnBinder
    {
        private Func<object, object> converter;
        public ColumnBinder()
        {
            As(input => Convert.ChangeType(input, Type));
        }
        public ColumnInfo Column { get; set; }
        public abstract Type Type { get; }
        
        #region ISqlColumnBinder
        public ISqlColumnBinder As(Func<object, object> converter)
        {
            this.converter = converter;
            return this;
        }
        public void From(string name)
        {
            Column = ColumnInfo.Get(name);
        }
        public void From(int index)
        {
            Column = ColumnInfo.Get(index);
        }
        #endregion
        public abstract void SetValue(ref object entity, object value);
        public object ChangeType(object value)
        {
            return converter(value);
        }
    }
}
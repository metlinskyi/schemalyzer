using System;

namespace MsSql.Client.Internal.Mapping
{
    internal class ValueBinder : ColumnBinder
    {
        private readonly Type type;
        public ValueBinder(Type type)
        {
            this.type = type;
        }
        public override Type Type => type;
        public override void SetValue(ref object entity, object value)
        {
            entity = ChangeType(value);
        }
    }
}
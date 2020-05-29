using System;
using System.Reflection;

namespace MsSql.Client.Internal.Mapping
{
    internal class PropertyBinder : ColumnBinder
    {
        public PropertyInfo Property { get; protected set; }
        public PropertyBinder(PropertyInfo property)
        {
            Property = property;
        }
        public override Type Type => Property.PropertyType;
        public override void SetValue(ref object entity, object value)
        {
            Property.SetValue(entity, ChangeType(value));
        }
    }
}
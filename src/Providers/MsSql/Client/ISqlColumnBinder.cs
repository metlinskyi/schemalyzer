using System;

namespace MsSql.Client.Internal
{
    public interface ISqlColumnBinder
    {
        ISqlColumnBinder As(Func<object, object> converter);
        void From(string name);
        void From(int index);
    }
}
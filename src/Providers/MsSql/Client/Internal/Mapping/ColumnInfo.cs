namespace MsSql.Client.Internal.Mapping
{
    internal abstract class ColumnInfo
    {
        private class ColumnInfoByIndex : ColumnInfo
        {
            private readonly int index;
            public ColumnInfoByIndex(int index)
            {
                this.index = index;
            }
            public override object GetValue(ISqlDataReader reader)
            {
                return reader[index];
            }
        }

        private class ColumnInfoByName : ColumnInfo
        {
            private readonly string name;
            public ColumnInfoByName(string name)
            {
                this.name = name;
            }
            public override object GetValue(ISqlDataReader reader)
            {
                return reader[name];
            }
        }
        
        public static ColumnInfo Get(string name)
        {
            return new ColumnInfoByName(name);
        }
        public static ColumnInfo Get(int index)
        {
            return new ColumnInfoByIndex(index);
        }
        public abstract object GetValue(ISqlDataReader reader);
    }
}
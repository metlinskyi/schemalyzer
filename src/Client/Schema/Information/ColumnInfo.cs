namespace Client.Schema.Information
{
    public class ColumnInfo : InformationSchema
    {
        public EntityInfo Entity { get; set; }

        public DataTypeInfo DataType { get; set; }
    }
}
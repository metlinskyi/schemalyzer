namespace MsSql.Client
{
    public interface ISqlDataReader
    {
        object this[string name] { get; set; }
    }
}
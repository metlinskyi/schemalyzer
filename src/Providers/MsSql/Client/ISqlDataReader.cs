namespace MsSql.Client
{
    public interface ISqlDataReader
    {
        object this[string name] { get; }
        object this[int index] { get; }
    }
}
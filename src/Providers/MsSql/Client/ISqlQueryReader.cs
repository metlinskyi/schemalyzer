namespace MsSql.Client
{
    public interface ISqlQueryReader
    {
        string Read<TQuery>() where TQuery : SqlQuery;
    }
}
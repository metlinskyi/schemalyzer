using Client.Schema.Information;

namespace MsSql.Schema.Queries
{
    public class TablesQuery : MsSql.Client.SqlQuery<TableInfo>
    {
        public TablesQuery(string name)
        {
            //Parametr("/*DATABASE_NAME.*/", name);
        }
    }
}
using MsSql.Client;

namespace MsSql.Schema.Queries
{
    public class ScriptQuery : SqlQuery<string>
    {
        public ScriptQuery(string database, string objname)
        {
            Repalce("[master]", database.ToDatabaseName());
            Parameter("@objname", objname);
        }       
        public override string ToString()
        {
            return string.Join(string.Empty, this);
        }
        protected override string Mapping(ISqlDataReader reader)
        {
            return reader[0].ToString();
        }
    }
}
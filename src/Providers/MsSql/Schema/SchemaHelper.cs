using Client.Schema.Information;

namespace MsSql
{
    public static class SchemaHelper
    {
        public static string ToDatabaseName(this string value)
        {
            return $"[{string.Join("].[", value.Split('.'))}]";
        }  
        public static string GetName(this DatabaseInfo databaseInfo)
        {
            return databaseInfo.Name.ToDatabaseName();
        }
        public static string GetName(this EntityInfo entityInfo)
        {
            return entityInfo.Name.ToDatabaseName();
        }  
        public static string GetName(this ColumnInfo columnInfo)
        {
            return columnInfo.Name.ToDatabaseName();
        }  
        public static string GetEntityName(this ColumnInfo columnInfo)
        {
            return columnInfo.Entity.GetName();
        }   
        public static string GetDatabaseName(this ColumnInfo columnInfo)
        {
            return columnInfo.Entity.Database.GetName();
        }   
    }
}
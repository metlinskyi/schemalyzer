using Client.Schema.Information;
using System.Collections.Generic;
using System.Linq;

namespace MsSql
{
    using Schema.Queries;
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
        public static bool IsMatch(this ReferencesEntity references, ColumnInfo columnInfo)
        {
            if(columnInfo.Name != references.referenced_minor_name)
            {
                return false;
            }
            if(columnInfo.Entity.Name != $"{references.referenced_schema_name}.{references.referenced_entity_name}")
            {
                return false;
            }

            return true;
        }
        public static IEnumerable<ReferenceInfo> ToReferenceInfo(this IEnumerable<ReferencesEntity> references, DatabaseInfo db)
        {
            return references
                    .SelectMany(reference => db.Tables
                        .SelectMany(table => table.Columns)
                        .Where(table => reference.IsMatch(table)))
                        .GroupBy(column => column.Entity)
                        .Select(group => new ReferenceInfo 
                        {
                            Entity = group.Key,
                            Columns = group.ToArray()
                        });
        }
    }
}
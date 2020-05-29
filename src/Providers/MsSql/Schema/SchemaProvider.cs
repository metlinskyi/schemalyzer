using System;
using System.Collections.Generic;
using System.Linq;
using Client.Schema;
using Client.Schema.Information;

namespace MsSql.Schema
{
    using Queries;
    public class SchemaProvider : ISchemaProvider
    {       
        private readonly Client.SqlClient _client;
        private readonly IDictionary<string, Func<EntityInfo>> _factory; 
        public SchemaProvider(string connectionString)
        {
            _client = new MsSql.Client.SqlClient(connectionString);
            _factory = new Dictionary<string, Func<EntityInfo>>
            {
                { "BASE TABLE"  , ()=> new TableInfo() },
                { "VIEW"        , ()=> new ViewInfo() },
            };
        }
        public IEnumerable<DatabaseInfo> Databases()
        {
            foreach(var db in _client.Execute(new DatabasesQuery()).Select(x => new DatabaseInfo{ Name = x }))
            {
                var schema = _client
                    .Execute(new SchemaQuery(db.Name))
                    .GroupBy(x => new 
                    { 
                        x.TABLE_TYPE,
                        x.TABLE_SCHEMA, 
                        x.TABLE_NAME
                    })
                    .Select(x =>
                    { 
                        var entity = _factory[x.Key.TABLE_TYPE]();
                        entity.Database = db;
                        entity.Name = GetName(x.Key.TABLE_SCHEMA,x.Key.TABLE_NAME);
                        entity.Columns = x.Select(c => new ColumnInfo
                        { 
                            Entity = entity,
                            Name = c.COLUMN_NAME, 
                            DataType = new DataTypeInfo
                            { 
                                Name = string.IsNullOrEmpty(c.CHARACTER_MAXIMUM_LENGTH) 
                                    ? c.DATA_TYPE 
                                    : $"{ c.DATA_TYPE }({ c.CHARACTER_MAXIMUM_LENGTH })",
                                IsNullable = c.IS_NULLABLE
                            }
                        })
                        .ToArray();
                        
                        return entity;
                    })
                    .ToArray();

                db.Tables = schema.OfType<TableInfo>().ToArray();
                
                db.Views = schema.OfType<ViewInfo>()
                    .Select(x =>
                    {
                        x.Source = _client.Execute(new ScriptQuery(db.Name, x.Name)).ToString();

                        var references = _client.Execute(new ReferencesQuery(db.Name, x.Name));

                        return x;
                    })
                    .ToArray(); 

                db.Routines = _client.Execute(new RoutineQuery(db.Name))
                    .Select(x =>
                    { 
                        var name = GetName(x.ROUTINE_SCHEMA, x.ROUTINE_NAME);

                        var references = _client.Execute(new ReferencesQuery(db.Name, name));

                        return new RoutineInfo
                        { 
                            Name = name,
                            Source = _client.Execute(new ScriptQuery(db.Name, name)).ToString()
                        };
                    })
                    .ToArray();

                yield return db;
            }
        }
        private static string GetName(string schema, string name)
        {
            return $"{ schema }.{ name }";
        }
    }

}
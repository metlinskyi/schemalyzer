using System;
using MsSql.Client;
using System.Collections.Generic;

namespace MsSql.Schema.Queries
{
    public class SchemaQuery : SqlQuery<SchemaEntity>
    {
        public SchemaQuery(string database)
        {
            Repalce("[master]", database.ToDatabaseName());
        }
        protected override void Mapping(ISqlRowMapper<SchemaEntity> mapper)
        {
            mapper.For(() => new SchemaEntity());
            mapper.For(x => x.TABLE_SCHEMA);   
            mapper.For(x => x.TABLE_NAME);  
            mapper.For(x => x.TABLE_TYPE);     
            mapper.For(x => x.COLUMN_NAME);       
            mapper.For(x => x.IS_NULLABLE).As(value => Convert(value.ToString()));
            mapper.For(x => x.DATA_TYPE);
            mapper.For(x => x.CHARACTER_MAXIMUM_LENGTH);
            mapper.For(x => x.CONSTRAINT_TYPE);
            mapper.For(x => x.CONSTRAINT_NAME);
        }
        protected override void Result(IEnumerable<SchemaEntity> entities)
        {
        }
        private static bool Convert(string value, string trueValue = "YES", string falseValue = "NO")
        {
            if(string.Compare(value, trueValue) == 0)
            {
                return true;
            }
            if(string.Compare(value, falseValue) == 0)
            {
                return false;
            }
            throw new ArgumentException("The value is not boolean.", nameof(value));
        }
    }
}
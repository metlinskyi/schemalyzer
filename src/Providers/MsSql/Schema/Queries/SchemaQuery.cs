using System;
using System.Data.SqlClient;

namespace MsSql.Schema.Queries
{
    public class SchemaQuery : MsSql.Client.SqlQuery<SchemaEntity>
    {
        public SchemaQuery(string database)
        {
            Repalce("[master]", database.ToDatabaseName());
        }
        protected override SchemaEntity Mapping(SqlDataReader reader)
        {
            return new SchemaEntity
            {
                TABLE_SCHEMA = reader["TABLE_SCHEMA"].ToString(),
                TABLE_NAME = reader["TABLE_NAME"].ToString(),
                TABLE_TYPE = reader["TABLE_TYPE"].ToString(),
                COLUMN_NAME = reader["COLUMN_NAME"].ToString(),
                IS_NULLABLE = Convert(reader["IS_NULLABLE"].ToString()),
                DATA_TYPE = reader["DATA_TYPE"].ToString(),
                CHARACTER_MAXIMUM_LENGTH = reader["CHARACTER_MAXIMUM_LENGTH"].ToString(),
                CONSTRAINT_TYPE = reader["CONSTRAINT_TYPE"].ToString(),
                CONSTRAINT_NAME = reader["CONSTRAINT_NAME"].ToString()
            };
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
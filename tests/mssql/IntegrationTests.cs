using System;
using System.Linq;
using Xunit;
using Client.Schema;
using Client.Data;
using MsSql.Schema.Queries;
using Client.Schema.Information;

namespace tests.mssql
{
    public class IntegrationTests
    {
        private readonly MsSql.Client.SqlClient client = 
            new MsSql.Client.SqlClient("Server=tcp:localhost,1433;User Id=sa;Password=Passw0rd!");
        private static DatabaseInfo databaseInfo = 
            new DatabaseInfo
            {
                Name = "A"
            };
        private static TableInfo tableInfo = 
            new TableInfo
            {
                Database = databaseInfo,
                Name = "Dictionary.GenderType"
            };

        [Fact]
        public void Execute_DatabasesQuery()
        {
            var actual = client.Execute(new DatabasesQuery()).FirstOrDefault();
            Assert.True(actual.Name == "A", $"The database name is {actual.Name}.");
        }
        [Fact]
        public void Execute_TablesQuery()
        {
            var query = new TablesQuery(databaseInfo);
            var actual = client.Execute(query).FirstOrDefault(x=>x.Name == "Dictionary.ContactType");
            Assert.True(actual != null, query.Query);
            Assert.True(actual.Name == "Dictionary.ContactType", $"The table name is {actual.Name}.");
        }
        [Fact]
        public void Execute_ColumnsQuery()
        {
            var query = new ColumnsQuery(tableInfo);
            var actual = client.Execute(query).FirstOrDefault(x=>x.Name == "Active");
            Assert.True(actual != null, query.Query);
            Assert.True(actual.Name == "Active", $"The column name is {actual.Name}.");
        }
    }
}
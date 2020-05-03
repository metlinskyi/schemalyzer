using System;
using System.Linq;
using Xunit;
using Client.Schema;
using Client.Data;
using MsSql.Schema.Queries;

namespace tests.mssql
{
    public class ClientIntegrationTests
    {
        private readonly MsSql.Client.SqlClient client = 
            new MsSql.Client.SqlClient("Server=tcp:localhost,1433;User Id=sa;Password=Passw0rd!");

        [Fact]
        public void DatabasesQuery()
        {
            var actual = client.Execute(new DatabasesQuery()).First();

            Assert.True(actual.Name == "A" , $"The database name is {actual.Name}.");
        }

        [Fact]
        public void TablesQuery()
        {
            var actual = client.Execute(new TablesQuery("A")).First();

            Assert.True(actual.Name == "Contact" , $"The table name is {actual.Name}.");
        }
    }
}
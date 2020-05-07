using System;
using System.Linq;
using Xunit;
using Client.Schema;
using Client.Schema.Information;
using Client.Data;
using MsSql.Schema.Queries;

namespace tests.mssql
{
    public class IntegrationTests
    {
        private readonly MsSql.Client.SqlClient client = 
            new MsSql.Client.SqlClient("Server=tcp:localhost,1433;User Id=sa;Password=Passw0rd!");

        [Fact]
        public void Execute_DatabasesQuery()
        {           
            var query = new DatabasesQuery();
            var actual = client.Execute(query).FirstOrDefault();
            Assert.True(actual != null, query.Query);
            Assert.True(actual == "A", $"The database name is {actual}.");
        }
        [Fact]
        public void Execute_SchemaQuery()
        {
            var query = new SchemaQuery("A");
            var actual = client.Execute(query).FirstOrDefault(x=>x.TABLE_NAME == "ContactType");
            Assert.True(actual != null, query.Query);
            Assert.True(actual.TABLE_NAME == "ContactType", $"The table name is {actual.TABLE_NAME}.");
        }
        [Fact]
        public void Execute_RoutineQuery()
        {
            var query = new RoutineQuery("A");
            try
            {
                var actual = client.Execute(query).FirstOrDefault(x=>x.ROUTINE_NAME == "CustomerContactsInsert");
                Assert.True(actual != null, query.Query);
                Assert.True(actual.ROUTINE_NAME == "CustomerContactsInsert", $"The routine name is {actual.ROUTINE_NAME}.");
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                Assert.True(false, e.Message + query.Query);
            }
        }
        [Fact]
        public void Execute_ScriptQuery()
        {
            var query = new ScriptQuery("A", "Entity.CustomerContactsInsert");
            try
            {
                var actual = client.Execute(query).ToString();
                Assert.True(actual != null, query.Query);
                Assert.True(actual.Contains("CustomerContactsInsert"), $"The script {actual}.");
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                Assert.True(false, e.Message + query.Query);
            }
        }
    }
}
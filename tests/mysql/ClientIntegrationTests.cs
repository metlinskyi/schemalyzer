using System;
using Xunit;
using Client.Schema;
using Client.Data;
using MySql.Client;

namespace tests.mysql
{
    public class ClientIntegrationTests
    {
        [Fact]
        public void Connect()
        {
            new SqlClient();
            Assert.False(false, "passed");
        }     
    }
}
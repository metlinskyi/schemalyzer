using System;
using Xunit;
using Client.Schema;
using Client.Data;

namespace tests.mysql
{
    public class ClientIntegrationTests
    {
        [Fact]
        public void Connect()
        {
            new MySql.MsSqlClient();
            Assert.False(false, "passed");
        }     
    }
}
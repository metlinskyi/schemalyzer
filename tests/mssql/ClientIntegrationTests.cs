using System;
using Xunit;
using Client.Schema;
using Client.Data;

namespace tests.mssql
{
    public class ClientIntegrationTests
    {
        [Fact]
        public void Connect()
        {
            new MsSql.MsSqlClient();
            Assert.False(false, "passed");
        }
    }
}
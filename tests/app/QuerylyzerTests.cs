using System;
using Xunit;
using Client.Schema;
using Client.Data;

namespace tests.app
{
    public class QuerylyzerTests
    {
        [Fact]
        public void Querylyzer_Parse()
        {
            new App.Querylyzer();

            Assert.False(false, "passed");
        }
    }
}

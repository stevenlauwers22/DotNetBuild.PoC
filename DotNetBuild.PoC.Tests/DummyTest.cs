using System;
using Xunit;

namespace DotNetBuild.PoC.Tests
{
    public class DummyTest
    {
        [Fact]
        public void Randomly_fails()
        {
            Assert.True((DateTime.Now.Second % 2) > 0);
        }
    }
}
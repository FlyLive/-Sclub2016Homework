using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeProblem.Test
{
    public class UnitTestDemoTest
    {
        private readonly UnitTestDemo _unitTestDemo;

        public UnitTestDemoTest()
        {
            _unitTestDemo = new UnitTestDemo();
        }

        [Fact]
        public void IsHelloWorldTest()
        {
            var result = _unitTestDemo.IsHelloWorld("sadsadsad");
            Assert.True(result);
        }
    }
}

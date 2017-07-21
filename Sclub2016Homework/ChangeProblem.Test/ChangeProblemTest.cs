using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeProblem
{
    public class ChangeProblemTest
    {
        private readonly ChangeProblemLib calculator;

        public ChangeProblemTest()
        {
            calculator = new ChangeProblemLib();
        }

        [Fact]
        public void OneMutiOneIsOne()
        {
            var result = calculator.Multi(1, 1);
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ReturnValue(int value)
        {
            var result = calculator.Multi(1, value);

            Assert.Equal(result, value);
        }
    }
}

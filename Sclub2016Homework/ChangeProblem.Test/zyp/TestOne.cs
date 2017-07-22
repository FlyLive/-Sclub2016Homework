using System;
using Xunit;

namespace ChangeProblem.Test.zyp
{
    public class TestOne
    {
        private static decimal[] denomination = { 100, 50, 20, 10, 5, 1, 0.5M, 0.1M };//确定钱柜钱面值

        private static PhaseOne phaseOne = new PhaseOne();

        #region 版本一
        [Theory]
        [InlineData(150.00, 122.80, 27.20)]
        [InlineData(300.00, 222.80, 77.20)]
        public void BalanceTest(decimal pay, decimal price, decimal exceptChange)
        {
            decimal change = phaseOne.Balance(pay, price);
            Assert.Equal(exceptChange, change);
        }

        [Theory]
        [InlineData(27.20)]
        public void OptimalNumOfChangeTest(decimal change)
        {
            int[] actualNumOfPay = phaseOne.OptimalNumOfChange(change, denomination);//实际找零钱的张数
            int[] expectedPay = { 0, 0, 1, 0, 1, 2, 0, 2 };//期望的最优找零钱
            Assert.Equal(expectedPay, actualNumOfPay);
        }
        #endregion
    }
}

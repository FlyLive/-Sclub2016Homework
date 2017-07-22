using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeProblem.zyp
{
    public class TestTwo
    {
        private static decimal[] denomination = { 100, 50, 20, 10, 5, 1, 0.5M, 0.1M };//确定钱柜钱面值；
        private static int[] numOfBox = { 0, 10, 0, 30, 20, 10, 10, 1 };//钱柜里钱的张数  

        private static PhaseTwo phaseTwo = new PhaseTwo();

        #region 版本二
        [Theory]
        [InlineData(150.00, 122.80, 27.20)]
        public void CaculateChange(decimal pay, decimal price, decimal exceptChange)
        {
            decimal actualChange = phaseTwo.Balance(pay, price);
            Assert.Equal(exceptChange, actualChange);
        }

        [Theory]
        [InlineData(27.20)]
        public void ChangeMoney(decimal actualChange)
        {
            int[] numOfChange;//找零钱的张数
            
            numOfChange = phaseTwo.ActualNumOfChange(actualChange, denomination, numOfBox);//计算实际找钱张数
            int[] expectedPay = { 0, 0, 0, 2, 1, 2, 0, 2 };//期望的实际找零钱

            Assert.Equal(expectedPay, numOfChange);

            int[] numOfPay = { 1, 1, 0, 0, 0, 0, 0, 0 };//付款的钱的张数

            numOfBox = phaseTwo.ChangeMoney(numOfChange, numOfPay, numOfBox);

            int[] expectedBox = { 1, 11, 0, 28, 19, 8, 10, 8 };//期望的最优找零钱后的钱库剩余

            Assert.Equal(expectedBox, numOfBox);
        }
        #endregion
    }
}

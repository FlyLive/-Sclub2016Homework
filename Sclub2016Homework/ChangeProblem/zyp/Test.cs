using System;
using Xunit;

namespace ChangeProblem
{
    public class Test
    {
        PhaseOne phaseOne = new PhaseOne();
        [Theory]
        [InlineData(150.00, 122.80, 27.20)]
        [InlineData(300.00, 222.80, 77.20)]
        public void CaculateChange(decimal payMoney, decimal price, decimal exceptChange)
        {
            decimal change = phaseOne.Balance(payMoney, price);
            Assert.Equal(exceptChange, change);
        }
        [Theory]
        [InlineData(27.20)]
        public void FindNumOfChange(decimal change)
        {
            decimal[] denomination = { 50, 20, 10, 5, 1, 0.5M, 0.1M };//确定零钱面值
            int[] actualNumOfPay = phaseOne.OptimalNumOfChange(change, denomination);//实际找零钱的张数
            int[] expectedPay = { 0, 1, 0, 1, 2, 0, 2 };//期望的最优找零钱
            Assert.Equal(expectedPay, actualNumOfPay);
        }
        PhaseTwo phaseTwo = new PhaseTwo();
        [Fact]
        public void TestPhaseTwo()
        {
            decimal[] denomination = {100, 50, 20, 10, 5, 1, 0.5M, 0.1M };//确定钱柜钱面值；
            int[] numOfBox = {0, 10, 0, 30, 20, 10, 10, 10 };//钱柜里钱的张数            
            int[] numOfChange = new int[denomination.Length];//找零钱的张数
            var change = phaseTwo.Balance(150.00M,122.8M);
            Assert.Equal(27.20M, change);
            numOfChange = phaseTwo.ActualNumOfChange(change, denomination, numOfBox);//计算实际找钱张数
            int[] expectedPay = {0, 0, 0, 2, 1, 2, 0, 2 };//期望的实际找零钱
            Assert.Equal(expectedPay, numOfChange);
            int[] numOfPay = { 1, 1, 0, 0, 0, 0, 0, 0 };//付款的钱的张数
            numOfBox = phaseTwo.AddMoney(numOfChange, numOfPay, numOfBox);
            int[] expectedBox = { 1, 11, 0, 28, 19, 8, 10, 8 };//期望的最优找零钱
            Assert.Equal(expectedBox, numOfBox);
        }
    }
}

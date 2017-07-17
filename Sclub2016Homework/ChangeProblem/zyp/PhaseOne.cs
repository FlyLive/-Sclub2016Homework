using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeProblem
{
    class PhaseOne
    {
        //计算应找零钱
        public decimal Balance(decimal payMoney, decimal price)
        {
            return payMoney - price;
        }
        //计算最优应找零钱的张数
        public int[] OptimalNumOfChange(decimal change, decimal[] denomination)
        {
            int[] numOfChange = new int[denomination.Length];
            for (int i = 0; i < denomination.Length; i++)
            {
                numOfChange[i] = (int)(change / denomination[i]);
                change = (decimal)(change % denomination[i]);
            }
            return numOfChange;
        }
    }
}

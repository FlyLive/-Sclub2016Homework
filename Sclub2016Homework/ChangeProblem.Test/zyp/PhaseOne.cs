using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeProblem
{
    public class PhaseOne
    {
        /// <summary>
        /// 计算应找零钱
        /// </summary>
        /// <param name="pay"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public decimal Balance(decimal pay, decimal price)
        {
            return pay - price;
        }

        /// <summary>
        /// 计算最优应找零钱的张数
        /// </summary>
        /// <param name="change"></param>
        /// <param name="denomination"></param>
        /// <returns></returns>
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

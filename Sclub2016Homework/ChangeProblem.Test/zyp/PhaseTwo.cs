using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeProblem
{
    public class PhaseTwo
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
        /// 根据钱柜实际应找零钱的张数
        /// </summary>
        /// <param name="change"></param>
        /// <param name="denomination"></param>
        /// <param name="numOfBox"></param>
        /// <returns></returns>
        public int[] ActualNumOfChange(decimal change, decimal[] denomination,int[] numOfBox)
        {
            int[] numOfChange = new int[denomination.Length];
            for (int i = 0; i < denomination.Length; i++)
            {
                if (numOfBox[i] != 0)
                {
                    numOfChange[i] = (int)(change / denomination[i]);
                    change = (decimal)(change % denomination[i]);
                }
            }
            return numOfChange;
        }

        /// <summary>
        /// 找零钱后，钱柜的变化
        /// </summary>
        /// <param name="numOfChange"></param>
        /// <param name="numOfPay"></param>
        /// <param name="numOfBox"></param>
        /// <returns></returns>
        public int[] ChangeMoney(int[] numOfChange, int[] numOfPay, int[] numOfBox)
        {
            for (int i = 0; i < numOfChange.Length; i++)
            {
                numOfBox[i] += numOfPay[i] - numOfChange[i];
            }
            return numOfBox;
        }
    }
}

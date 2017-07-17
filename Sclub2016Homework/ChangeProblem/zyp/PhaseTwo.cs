using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeProblem
{
    class PhaseTwo
    {
        //计算应找零钱
        public decimal Balance(decimal pay, decimal money)
        {
            return pay - money;
        }
        //根据钱柜实际应找零钱的张数
        public int[] ActualNumOfChange(decimal balance, decimal[] denomination,int[] numOfBox)
        {
            int[] numOfChange = new int[denomination.Length];
            for (int i = 0; i < denomination.Length; i++)
            {
                if (numOfBox[i] != 0)
                {
                    numOfChange[i] = (int)(balance / denomination[i]);
                    balance = (decimal)(balance % denomination[i]);
                }
            }
            return numOfChange;
        }
        //找零钱后，钱柜的变化
        public int[] AddMoney(int[] numOfChange, int[] numOfPay, int[] numOfBox)
        {
            for (int i = 0; i < numOfChange.Length; i++)
            {
                numOfBox[i] += numOfPay[i] - numOfChange[i];
            }
            return numOfBox;
        }
    }
}

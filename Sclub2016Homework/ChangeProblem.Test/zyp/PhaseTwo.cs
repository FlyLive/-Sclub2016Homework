using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeProblem.Test.zyp
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
        /// 根据无条件应找零钱的张数
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
                if (change >= denomination[i] & numOfBox[i] != 0)
                {
                    numOfChange[i]++;
                    change -= denomination[i];
                    i--;
                }
            }
            return numOfChange;
        }

        /// <summary>
        /// 是否有找零方法
        /// </summary>
        /// <param name="changeOfNum"></param>
        /// <param name="values"></param>
        /// <param name="change"></param>
        /// <returns></returns>
        public bool HasChange(int[] changeOfNum,decimal[] values,decimal change)
        {
            decimal total = 0;

            for(int i = 0;i < changeOfNum.Length; i++)
            {
                total += changeOfNum[i] * values[i];
            }

            return total == change;
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
            int[] tempBox = NumOfBoxClone(numOfBox);

            for (int i = 0; i < numOfChange.Length; i++)
            {
                tempBox[i] += numOfPay[i] - numOfChange[i];
                if (tempBox[i] < 0)
                {
                    return numOfBox;//找不开
                }
            }
            numOfBox = tempBox;
            return numOfBox;
        }

        private int[] NumOfBoxClone(int[] numOfBox)
        {
            int[] newBox = new int[numOfBox.Length];
            for (int i = 0; i < numOfBox.Length; i++)
            {
                newBox[i] = numOfBox[i];
            }
            return newBox;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Coin_Change
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (coins != null && coins.Any() && amount != 0)
            {
                //Array.Sort(coins);
                //Array.Reverse(coins);
                Array.Sort<int>(coins, new Comparison<int>(
                 (i1, i2) => i2.CompareTo(i1)));
                var ret = Min(coins, amount, 0, 0, Int32.MaxValue);
                if (ret == Int32.MaxValue)
                {
                    return -1;
                }
                else
                {
                    return ret;
                }
            }
            else
            {
                return 0;
            }
        }

        private int Min(int[] coins, int remainingAmt, int coinsUsed, int currIndex, int minCoins)
        {
            for (int i = currIndex; i < coins.Length; i++)
            {
                var tempRemainingAmt = remainingAmt - coins[i];
                if (tempRemainingAmt == 0)
                {
                    return Math.Min(coinsUsed+1, minCoins);
                    //return coinsUsed + 1;
                }
                if (tempRemainingAmt >= 0)
                {
                    minCoins = Min(coins, tempRemainingAmt, coinsUsed + 1, i, minCoins);
                }
            }
            return minCoins;
        }
    }
}

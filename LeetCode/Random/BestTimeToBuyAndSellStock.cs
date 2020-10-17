using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BestTimeToBuyAndSellStock
    {
        public BestTimeToBuyAndSellStock()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Number Of 1 Bits");
            Console.WriteLine("----------------------------------------------------------");
        }

        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int pLength = prices.Length;

            for (int j = 0; j < pLength; j++)
            {
                for (int i = j + 1; i < pLength; i++)
                {
                    profit = Math.Max(profit, prices[i] - prices[j]);
                }
            }

            return profit;
        }
    }
}

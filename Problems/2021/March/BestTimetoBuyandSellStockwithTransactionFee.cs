using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.March
{
    class BestTimetoBuyandSellStockwithTransactionFee
    {
        private Dictionary<(int, bool), int> _dictionary;

        public int MaxProfit(int[] prices, int fee)
        {
            _dictionary = new Dictionary<(int, bool), int>();
            return Calculate(prices, 0, false, fee);
        }

        private int Calculate(int[] prices, int i, bool isPurchased, int fee)
        {
            if (i >= prices.Length)
            {
                return 0;
            }
            else
            {
                if (_dictionary.ContainsKey((i, isPurchased)))
                {
                    return _dictionary[(i, isPurchased)];
                }
                else
                {
                    int ret = 0;

                    if (isPurchased)
                    {
                        //***
                        //*** either sell or skip
                        //*** 
                        int sell1 = Calculate(prices, i + 1, false, fee) + prices[i] - fee;
                        int sell2 = Calculate(prices, i + 1, true, fee);

                        ret = Math.Max(sell1, sell2);
                    }
                    else
                    {
                        //***
                        //*** either buy or skip
                        //*** 
                        int buy1 = Calculate(prices, i + 1, true, fee) - prices[i];
                        int buy2 = Calculate(prices, i + 1, false, fee);

                        ret = Math.Max(buy1, buy2);
                    }

                    _dictionary.Add((i, isPurchased), ret);
                    return ret;
                }
            }
        }

        public int MaxProfit2(int[] prices, int fee)
        {
            int profit = 0;
            int hold = -prices[0];

            foreach (var item in prices)
            {
                profit = Math.Max(profit, hold + item - fee);
                hold = Math.Max(hold, profit - item);
            }

            return profit;
        }
    }
}

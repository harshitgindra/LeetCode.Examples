namespace LeetCode.August
{
    public class BestTimeToBuyAndSellStockIII
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int pLength = prices.Length;

            for (int i = 0; i < pLength; i++)
            {
                var firstRound = FindProfit(prices, i);
                int loopProfit = 0;
                if (firstRound.index + 1 < pLength && firstRound.profit > 0)
                {
                    var secondRound = FindProfit(prices, firstRound.index + 1);
                    loopProfit = secondRound.profit;
                }

                loopProfit += firstRound.profit;
                profit = Math.Max(loopProfit, profit);
            }

            return profit;
        }


        private (int profit, int index) FindProfit(int[] num, int startIndex)
        {
            int profit = 0;
            int index = 0;
            for (int i = startIndex; i < num.Length - 1; i++)
            {
                for (int j = i + 1; j < num.Length; j++)
                {
                    if (profit < num[j] - num[i])
                    {
                        profit = num[j] - num[i];
                        index = j;
                    }
                }
            }

            return (profit, index);
        }
    }
}
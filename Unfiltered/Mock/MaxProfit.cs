namespace LeetCode.Mock
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    /// </summary>
    class MaxProfitTest
    {
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                maxProfit = Math.Max(maxProfit, Trade(prices, i + 1, prices[i], maxProfit));
            }
            return maxProfit;
        }

        private int Trade(int[] prices, int day, int purchasedAt, int maxProfit)
        {
            for (int i = day; i < prices.Length; i++)
            {
                maxProfit = Math.Max(maxProfit, prices[i] - purchasedAt);
            }
            return maxProfit;
        }
    }
}

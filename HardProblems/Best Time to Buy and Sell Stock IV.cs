using NUnit.Framework.Legacy;

namespace LeetCode.Hard
{
    class Best_Time_to_Buy_and_Sell_Stock_IV
    {
        public int MaxProfit(int k, int[] prices)
        {
            return Trade(prices, k, false, 0, 0, 0, 0);
        }

        private int Trade(int[] prices, int k, bool isPurchased, int purchasedFor, int i, int profit, int maxProfit)
        {
            if (i == prices.Length || k == 0)
            {
                return Math.Max(profit, maxProfit);
            }
            else
            {
                for (int j = i; j < prices.Length; j++)
                {
                    if (!isPurchased)
                    {
                        maxProfit = Trade(prices, k, true, prices[j], j + 1, profit, maxProfit);
                    }
                    else if (prices[j] > purchasedFor)
                    {
                        var p = prices[j] - purchasedFor;
                        maxProfit = Trade(prices, k - 1, false, 0, j + 1, profit + p, maxProfit);
                    }
                }
            }

            return maxProfit;
        }

        [Test(Description = "https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Best Time to Buy and Sell Stock IV")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int, int[]) Input) item)
        {
            var response = MaxProfit(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int, int[]) Input)> Input
        {
            get
            {
                return new List<(int Output, (int, int[]) Input)>()
                {

                    (2,( 2, new int[] {2,4,1})),
                    (7,( 2, new int[] {3,2,6,5,0,3})),
                };
            }
        }
    }
}

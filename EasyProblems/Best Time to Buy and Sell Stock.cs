namespace LeetCode.EasyProblems
{
    public class BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int bestPriceToBuy = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                profit = Math.Max(profit, prices[i] - bestPriceToBuy);
                bestPriceToBuy = Math.Min(bestPriceToBuy, prices[i]);
            }

            return profit;
        }
        
        [Test(Description = "https://leetcode.com/problems/best-time-to-buy-and-sell-stock/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Best Time to Buy and Sell Stock")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaxProfit(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (5, ( [7,1,5,3,6,4])),
            };
    }
}
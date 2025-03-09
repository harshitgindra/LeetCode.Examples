namespace LeetCode.EasyProblems
{
    class Best_Time_to_Buy_and_Sell_Stock_II
    {
        public int MaxProfit(int[] prices)
        {
            int sum = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int diff = prices[i] - prices[i - 1];
                if (diff > 0)
                {
                    sum += diff;
                }
            }

            return sum;
        }

        [Test(Description = "https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Best Time to Buy and Sell Stock II")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaxProfit(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (8, ( [3,3,5,0,0,3,1,4])),
                    (7, ( [7,1,5,3,6,4])),
                    (4, ( [1,2,3,4,5])),
                    (0, ( [7,6,4,3,1])),
                };
            }
        }
    }
}

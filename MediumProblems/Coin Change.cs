namespace LeetCode.MediumProblems
{
    class Coin_Change
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (coins == null || coins.Length == 0)
                return 0;
            // this array each position indicates we are trying for that amount
            int[] dp = new int[amount + 1];
            // fill the array with max value 
            Array.Fill(dp, amount + 1);
            //no of coins required to make $0 
            dp[0] = 0;

            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[j])
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }

            return ((dp[amount] > amount) ? -1 : dp[amount]);
        }

        [Test(Description = "https://leetcode.com/problems/coin-change/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Coin Change")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = CoinChange(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (3, (new int[] { 1, 2, 5 }, 11)),
                };
            }
        }
    }
}
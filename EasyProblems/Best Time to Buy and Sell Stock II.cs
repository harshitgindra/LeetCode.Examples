using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Best_Time_to_Buy_and_Sell_Stock_II
    {
        public int[] PlusOne(int[] digits)
        {
            var nums = digits.ToList();

            if (nums.Last() == 9)
            {
                nums[digits.Length - 1] = 1;
                nums.Add(0);
            }
            else
            {
                nums[digits.Length - 1]++;
            }

            return nums.ToArray();
        }


        public int MaxProfit(int[] prices)
        {
            int result = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                result = Math.Max(result, Check(prices, prices[i], i + 1, 0, 0, 0, true));
            }
            return result;
        }

        private int Check(int[] prices, int buyPrice, int day, int transactionCount, int tempProfit, int maxProfit, bool isPurchased)
        {
            if (transactionCount == 2 || day >= prices.Length)
            {
                return Math.Max(tempProfit, maxProfit);
            }
            else
            {
                for (int i = day; i < prices.Length; i++)
                {
                    int dayPrice = prices[i];
                    if (isPurchased)
                    {

                        if (buyPrice < dayPrice)
                        {
                            int p = dayPrice - buyPrice;
                            tempProfit += p;

                            maxProfit = Check(prices, dayPrice, i + 1, transactionCount + 1, tempProfit, maxProfit, false);

                            tempProfit -= p;
                        }
                    }
                    else
                    {
                        maxProfit = Check(prices, prices[i], i + 1, transactionCount, tempProfit, maxProfit, true);
                    }
                }
                return maxProfit;
            }
        }

        [Test(Description = "https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Best Time to Buy and Sell Stock II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaxProfit(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (8, (new int[] {3,3,5,0,0,3,1,4})),
                    (7, (new int[] {7,1,5,3,6,4})),
                    (4, (new int[] {1,2,3,4,5})),
                    (0, (new int[] {7,6,4,3,1})),
                };
            }
        }
    }
}

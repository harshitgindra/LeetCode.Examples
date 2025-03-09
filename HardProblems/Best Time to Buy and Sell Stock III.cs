using NUnit.Framework.Legacy;

namespace LeetCode.Hard
{
    public class Best_Time_to_Buy_and_Sell_Stock_III
    {
        private int maxProfit;

        public int MaxProfit(int k, int[] prices)
        {
            Transact(false, 0, prices[0], 0, k, prices);
            return maxProfit;
        }

        void Transact(bool bought, int index, int lastPrice, int tempProfit, int transactions, int[] prices)
        {
            if (transactions == 0 || index == prices.Length)
            {
                maxProfit = Math.Max(tempProfit, maxProfit);
            }
            else
            {
                //***
                //*** previous transaction bought
                //***
                if (bought)
                {
                    var curr = prices[index];

                    if (curr > lastPrice)
                    {
                        Transact(false, index + 1, lastPrice, tempProfit + (curr - lastPrice), transactions - 1,
                            prices);
                    }
                }
                else
                {
                    var curr = prices[index];
                    Transact(true, index + 1, curr, tempProfit, transactions, prices);
                }

                //***
                //*** Do nothing
                //***

                Transact(bought, index + 1, lastPrice, tempProfit, transactions, prices);
            }
        }


        [Test(Description = "https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Best Time to Buy and Sell Stock IV")]
        [TestCaseSource(nameof(Input))]
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
                   // (2, (2, new int[] {2, 4, 1})),
                    (7, (2, new int[] {3, 2, 6, 5, 0, 3})),
                };
            }
        }
    }
}
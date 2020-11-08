using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Contest
{
    public class Sell_Diminishing_Valued_Colored_Balls
    {
        public int MaxProfit(int[] inventory, int orders)
        {
            Array.Reverse(inventory);

            int ret = 0;
            int m = 1000000007;
            for (int i = 0; i < orders; i++)
            {
                Array.Sort(inventory);

                if (ret > Int32.MaxValue - inventory[inventory.Length - 1])
                {
                    ret = (ret % m) + (inventory[inventory.Length - 1] % m);
                }
                else
                {
                    ret = (ret + inventory[inventory.Length - 1]);
                }

                inventory[inventory.Length - 1]--;
            }

            return ret;
        }

        [Test(Description = "https://leetcode.com/problems/binary-watch/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Binary Watch")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = MaxProfit(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) )> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    // (2, (new int[] {2, 5}, 4)),
                    (21, (new int[] {1000000000}, 1000000000)),
                };
            }
        }
    }
}
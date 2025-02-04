using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Leetcode.Problems._2022.January
{
    /// <summary>
    /// https://leetcode.com/problems/koko-eating-bananas/
    /// </summary>
    public class Koko_Eating_Bananas
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            int high = 0;

            if (piles != null && piles.Length > 0)
            {
                int low = 1;
                high = piles.Max();
                while (low < high)
                {
                    int middle = (low + high) / 2;

                    int hours = 0;
                    foreach (var item in piles)
                    {
                        hours += item / middle;
                        if (item % middle > 0)
                        {
                            hours++;
                        }
                    }

                    if (hours <= h)
                    {
                        high = middle;
                    }
                    else
                    {
                        low = middle +1;
                    }
                }
            }

            return high;
        }


        [Test(Description = "https://leetcode.com/problems/koko-eating-bananas/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Koko Eating Bananas")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = MinEatingSpeed(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (4, (new int[] {3,6,7,11}, 8)),
                    (23, (new int[] {30, 11, 23, 4, 20}, 6)),
                };
            }
        }
    }
}
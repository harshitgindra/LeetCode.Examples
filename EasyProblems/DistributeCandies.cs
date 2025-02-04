using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    public class DistributeCandiesTest
    {
        public int DistributeCandies(int[] candies)
        {
            int distinctCount = candies.Distinct().Count();
            return distinctCount < candies.Length / 2 ? distinctCount : candies.Length / 2;
        }

        [Test(Description = "https://leetcode.com/problems/distribute-candies/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Distribute Candies")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = DistributeCandies(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (2, new int[] {3,1,0,4}),
                    (2, new int[] {1,1,2,3}),
                    (3, new int[] {1,1,2,2,3,3}),
                    (2, new int[] {1000,1,1,1}),
                };
            }
        }
    }
}

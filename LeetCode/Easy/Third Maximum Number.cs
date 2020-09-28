using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    class Third_Maximum_Number
    {
        public int ThirdMax(int[] nums)
        {
            var hashset = nums.ToHashSet().OrderByDescending(x => x);

            if (hashset.Count() >= 3)
            {
                return hashset.Take(3).Last();
            }
            else
            {
                return hashset.First();
            }
        }

        [Test(Description = "https://leetcode.com/problems/third-maximum-number/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Third Maximum Number")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = ThirdMax(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (1, (new int[] {3, 2, 1})),
                    (2, (new int[] {1, 2})),
                    (1, (new int[] {2, 2, 3, 1})),
                };
            }
        }
    }
}

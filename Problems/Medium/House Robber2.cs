using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    public class House_Robber2
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            return Math.Max(Rob(nums, 0, nums.Length - 1), Rob(nums, 1, nums.Length - 1));
        }

        public int Rob(int[] nums, int start, int end)
        {
            int previousLevel1 = 0;
            int previousLevel2 = 0;
            int current = 0;
            for (int i = start; i <= end; i++)
            {
                current = Math.Max(nums[i] + previousLevel2, previousLevel1);
                previousLevel2 = previousLevel1;
                previousLevel1 = current;
            }
            return current;
        }

        [Test(Description = "https://leetcode.com/problems/house-robber-ii/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("House Robber 2")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = Rob(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (3, new int[] {2,3,2}),
                    (4, new int[] {1,2,3,1}),
                    (3, new int[] {1,2,1,1}),
                };
            }
        }
    }
}

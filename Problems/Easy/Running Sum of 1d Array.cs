using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Running_Sum_of_1d_Array
    {
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i]+= nums[i-1];
            }

            return nums;
        }

        [Test(Description = "https://leetcode.com/problems/running-sum-of-1d-array/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Running Sum of 1d Array")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = RunningSum(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {

                    (new int[]{ 1,3,6,10}, (new int[] {1,2,3,4})),
                };
            }
        }

    }
}

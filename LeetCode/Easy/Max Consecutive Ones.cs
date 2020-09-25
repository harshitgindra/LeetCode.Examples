using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Max_Consecutive_Ones
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int returnValue = 0;

            int index = 0;
            int tempCount = 0;
            while (index < nums.Length)
            {
                if (nums[index] == 1)
                {
                    tempCount++;
                }
                else
                {
                    returnValue = Math.Max(tempCount, returnValue);
                    tempCount = 0;
                }
                index++;
            }

            returnValue = Math.Max(tempCount, returnValue);
            return returnValue;
        }


        [Test(Description = "https://leetcode.com/problems/max-consecutive-ones/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Max Consecutive Ones")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindMaxConsecutiveOnes(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (3, new int[] {1,1,0,1,1,1}),
                };
            }
        }
    }
}

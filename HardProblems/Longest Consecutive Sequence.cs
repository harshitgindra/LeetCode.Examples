using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Hard
{
    class Longest_Consecutive_Sequence
    {
        public int LongestConsecutive(int[] nums)
        {
            int returnValue = 0;
            if (nums != null && nums.Length > 0)
            {
                if (nums.Length == 1)
                {
                    returnValue = 1;
                }
                else
                {
                    int tempReturnValue = 1;
                    Array.Sort(nums);
                    for (int i = 0; i < nums.Length - 1; i++)
                    {
                        if (nums[i] == nums[i + 1])
                        {

                        }
                        else if (nums[i] + 1 == nums[i + 1])
                        {
                            tempReturnValue++;
                        }
                        else
                        {
                            returnValue = Math.Max(returnValue, tempReturnValue);
                            tempReturnValue = 1;
                        }
                    }
                    returnValue = Math.Max(returnValue, tempReturnValue);
                }
            }

            return returnValue;
        }


        [Test(Description = "https://leetcode.com/problems/longest-consecutive-sequence/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Longest Consecutive Sequence")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = LongestConsecutive(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (4, new int[] {100, 4, 200, 1, 3, 2}),
                    (2, new int[] {0, -1}),
                };
            }
        }
    }
}

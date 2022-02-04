using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.Medium
{
    class Find_Peak_Element
    {
        public int FindPeakElement(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    if (nums.Length > i + 1)
                    {
                        if (nums[i] > nums[i + 1])
                        {
                            return i;
                        }
                    }
                    else
                    {
                        return i;
                    }
                }
            }

            return 0;
        }

        [Test(Description = "https://leetcode.com/problems/find-peak-element/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Find Peak Element")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindPeakElement(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (1, new int[] {1,2,1,3,5,6,4}),
                    (2, new int[] {1,2,3,1}),
                };
            }
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Remove_Duplicates_from_Sorted_Array_II
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int currIndex = 0, count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[currIndex])
                {
                    nums[++currIndex] = nums[i];
                    count = 0;
                }
                else if (count < 2)
                {
                    nums[++currIndex] = nums[i];
                }
                count++;
            }
            return currIndex + 1;
        }

        [Test(Description = "https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Remove Duplicates from Sorted Array II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = RemoveDuplicates(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (1, new int[] {0,0,1,1,1,1,2,2,2,4}),
                    (5, new int[] {1,1,1, 1,2,2,3}),
                    (7, new int[] {0,0,1,1,1,1,2,3,3}),
                    (5, new int[] {1,1,1,2,2,3}),
                };
            }
        }
    }
}

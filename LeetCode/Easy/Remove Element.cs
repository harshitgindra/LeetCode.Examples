using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Remove_Element
    {
        public int RemoveElement(int[] nums, int val)
        {
            int returnValue = 0;

            if (nums != null && nums.Length > 0)
            {
                Array.Sort(nums);

                int index = 0;
                int nextIndex = 0;
                while (index < nums.Length)
                {
                    if (nums[index] == val)
                    {
                        nums[index] = nums[nextIndex];
                        nextIndex++;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Remove Duplicates from Sorted Array II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = RemoveElement(item.Input.Item1, item.Input.Item2);
            //Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {

                    (2, (new int[] {3,2,2,3}, 3)),
                    (5, (new int[] {0,1,2,2,3,0,4,2}, 2)),
                };
            }
        }
    }
}

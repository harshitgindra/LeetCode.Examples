using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    class Remove_Element
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums != null && nums.Length > 0)
            {
                int returnValue = nums.Length;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == val)
                    {
                        nums[i] = int.MaxValue;
                        returnValue--;
                    }
                }

                Array.Sort(nums);
                return returnValue;
            }
            else
            {
                return 0;
            }
        }

        [Test(Description = "https://leetcode.com/problems/remove-element/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Remove Element")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = RemoveElement(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
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

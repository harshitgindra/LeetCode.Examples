using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Move_Zeroes
    {
        public void MoveZeroes(int[] nums)
        {
            int moveLeft = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    moveLeft++;
                }
                else
                {
                    nums[i - moveLeft] = nums[i];
                    if (moveLeft != 0)
                    {
                        nums[i] = 0;
                    }
                }
            }
        }


        [Test(Description = "https://leetcode.com/problems/move-zeroes/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Move Zeroes")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            MoveZeroes(item.Input);
            Assert.AreEqual(item.Output, item.Input);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {

                    (new int[]{ 1,3,12,0,0}, (new int[] {0,1,0,3,12})),
                };
            }
        }
    }
}

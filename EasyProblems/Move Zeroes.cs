﻿

namespace LeetCode.EasyProblems
{
    class Move_Zeroes
    {
        public void MoveZeroes(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }

            for (int i = j; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }


        [Test(Description = "https://leetcode.com/problems/move-zeroes/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Move Zeroes")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[] Input) item)
        {
            MoveZeroes(item.Input);
            Assert.That(item.Input, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input =>
            new List<(int[] Output, int[] Input)>()
            {

                ([1,3,12,0,0], ( [0,1,0,3,12])),
            };
    }
}

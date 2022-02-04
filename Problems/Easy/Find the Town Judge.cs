using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Find_the_Town_Judge
    {
        public int FindJudge(int N, int[][] trust)
        {
            int[] nums = new int[N];

            foreach (var item in trust)
            {
                nums[item[1] - 1]++;
                nums[item[0] - 1]--;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == N - 1)
                {
                    return i + 1;
                }
            }

            return -1;
        }


        [Test(Description = "https://leetcode.com/problems/find-the-town-judge/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Find the Town Judge")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int, int[][]) Input) item)
        {
            var response = FindJudge(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int, int[][]) Input)> Input
        {
            get
            {
                return new List<(int Output, (int, int[][]) Input)>()
                {
                    (3, (3, new int[][] { new int[]{ 1,3}, new int[]{ 2,3} })),
                    (-1, (3, new int[][] { new int[]{ 1,3}, new int[]{ 2,3}, new int[]{ 3,1} })),
                };
            }
        }
    }
}

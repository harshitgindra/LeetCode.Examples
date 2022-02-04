using LeetCode.Medium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Hard
{
    class MinimumDifficultyofaJobSchedule
    {
        private IDictionary<int, int> _max;

        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            return 0;
        }


        [Test(Description = "https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Minimum Difficulty of a Job Schedule")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = MinDifficulty(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (-1, (new int[] {1, 1, 1}, 4)),
                    (3, (new int[] {1, 1, 1}, 3)),
                    (7, (new int[] {6, 5, 4, 3, 2, 1}, 2)),
                    (6, (new int[] {1, 5, 3, 2, 4}, 2)),
                    (10, (new int[] {1, 5, 3, 2, 4}, 3)),
                };
            }
        }
    }
}
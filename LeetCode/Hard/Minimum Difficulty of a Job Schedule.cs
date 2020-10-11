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
            int ret = -1;
            if (jobDifficulty != null && jobDifficulty.Length >= d)
            {
                if (jobDifficulty.Length == d)
                {
                    ret = jobDifficulty.Sum();
                }
                else
                {
                    _max = new Dictionary<int, int>();
                    ret = Find(jobDifficulty, d, 0, 0, int.MaxValue);
                }
            }

            return ret;
        }

        private int Find(int[] nums, int remainingDays, int currIndex, int calcComplexity, int minComplexity)
        {
            if (remainingDays == 1)
            {
                int remainingMax = 0;
                if (_max.ContainsKey(currIndex))
                {
                    remainingMax = _max[currIndex];
                }
                else
                {
                    for (int i = currIndex; i < nums.Length; i++)
                    {
                        if (nums[i] > remainingMax)
                        {
                            remainingMax = nums[i];
                        }
                    }
                    _max.Add(currIndex, remainingMax);
                }

                minComplexity = Math.Min(minComplexity, calcComplexity + remainingMax);
            }
            else
            {
                var tempCalcComplexity = 0;

                for (var i = currIndex; i <= nums.Length - remainingDays; i++)
                {
                    if (nums[i] > tempCalcComplexity)
                    {
                        if (calcComplexity + nums[i] > minComplexity)
                        {
                            break;
                        }
                        else
                        {
                            tempCalcComplexity = nums[i];
                        }
                    }

                    minComplexity = Find(nums, remainingDays - 1, i + 1, calcComplexity + tempCalcComplexity, minComplexity);
                }
            }

            return minComplexity;
        }


        [Test(Description = "https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/")]
        [Category("Hard")]
        [Category("Leetcode")]
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

                    (-1, (new int[] {1,1,1}, 4)),
                    (3, (new int[] {1,1,1}, 3)),
                    (7, (new int[] {6,5,4,3,2, 1}, 2)),
                    (6, (new int[] {1,5,3,2,4}, 2)),
                    (10, (new int[] {1,5,3,2,4}, 3)),
                };
            }
        }
    }
}

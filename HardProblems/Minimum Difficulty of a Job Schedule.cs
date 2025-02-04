using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework.Legacy;
using CategoryAttribute = NUnit.Framework.CategoryAttribute;

namespace LeetCode.Hard
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
    /// </summary>
    class MinimumDifficultyofaJobSchedule
    {
        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            // Basic validation to job difficulty and days combinatio 
            if (jobDifficulty == null || jobDifficulty.Length == 0
                || jobDifficulty.Length < d)
            {
                return -1;
            }

            // Initializing dynamic programming array
            int[][] dp = new int[d + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[jobDifficulty.Length];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = Int32.MaxValue;
                }
            }

            return _dfs(dp, jobDifficulty, d, 0);
        }

        private int _dfs(int[][] dp, int[] jobDifficulty, int d, int breakPoint)
        {
            // Run the iteration only if thereare any days left
            if (d > 0)
            {
                // If the value is not Int32.MaxValue, it means we have already calculated
                // the most efficient job combo and saved in dp, skip the iteration again
                if (dp[d][breakPoint] == Int32.MaxValue)
                {
                    if (d == 1)
                    {
                        int returnValue = 0;
                        // Already the last day of the assigned time lime
                        // need to find out the max work value out of the remaining jobs
                        for (int i = breakPoint; i < jobDifficulty.Length; i++)
                        {
                            returnValue = Math.Max(returnValue, jobDifficulty[i]);
                        }
                        dp[d][breakPoint] = returnValue;
                    }
                    else
                    {
                        int maxJobValue = Int32.MaxValue;
                        int currentJobValue = 0;

                        for (int i = breakPoint; i <= jobDifficulty.Length - d; i++)
                        {
                            // Saving the current max by calculating max job value that can be done on day d
                            currentJobValue = Math.Max(currentJobValue, jobDifficulty[i]);

                            // Calculating the job value that needs to be completed in the remaining days(best possible case
                            int remainingJobs = _dfs(dp, jobDifficulty, d - 1, i + 1);
                            // Compare the current combination of job breakdown with any previous combination and save
                            // the min value only
                            maxJobValue = Math.Min(maxJobValue, currentJobValue + remainingJobs);
                        }

                        dp[d][breakPoint] = maxJobValue;
                    }
                }
                return dp[d][breakPoint];
            }

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
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (13, (new int[] {6, 5, 4, 3, 2, 1, 7}, 2)),
                    (-1, (new int[] {1, 1, 1}, 4)),
                    (3, (new int[] {1, 1, 1}, 3)),
                    (6, (new int[] {1, 5, 3, 2, 4}, 2)),
                    (10, (new int[] {1, 5, 3, 2, 4}, 3)),
                };
            }
        } // 444, 111,11,22,33,44
    }
}
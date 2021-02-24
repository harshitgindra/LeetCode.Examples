using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Medium
{
    public class Partition_Equal_Subset_Sum
    {
        public bool CanPartition(int[] nums)
        {
            if (nums != null && nums.Length > 1)
            {
                int sum = nums.Sum();

                if (sum % 2 == 0)
                {
                    var half = sum / 2;
                    Array.Sort(nums);

                    var dp = new bool[nums.Length + 1, half + 1];

                    for (int i = 0; i <= nums.Length; i++)
                    {
                        dp[i, 0] = true;
                    }


                    for (int i = 1; i <= nums.Length; i++)
                    {
                        for (int j = 1; j <= half; j++)
                        {
                            var num = nums[i - 1];

                            if (dp[i - 1, j])
                            {
                                dp[i, j] = true;
                            }
                            else
                            {
                                int tempj = j - num;
                                if (tempj < 0)
                                {
                                    dp[i, j] = false;
                                }
                                else
                                {
                                    var t = dp[i - 1, tempj];
                                    dp[i, j] = dp[i - 1, tempj];
                                }
                            }
                        }
                    }

                    return dp[nums.Length, half];
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/partition-equal-subset-sum/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Partition Equal Subset Sum")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = CanPartition(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    //(2, new int[] {2, 2, 1, 1}),
                    (2, new int[] {14, 9, 8, 4, 3, 2}),
                    (2, new int[] {1, 5, 11, 5}),
                };
            }
        }
    }
}
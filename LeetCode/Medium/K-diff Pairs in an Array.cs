using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class K_diff_Pairs_in_an_Array
    {

        public int FindPairs(int[] nums, int k)
        {
            if (nums != null && nums.Length > 1)
            {
                Array.Sort(nums);
                HashSet<(int, int)> combo = new HashSet<(int, int)>();

                for (int i = 0; i < nums.Length - 1; i++)
                {
                    int tempIndex = i + 1;

                    while (tempIndex < nums.Length)
                    {
                        int diff = nums[tempIndex] - nums[i];

                        if (diff == k)
                        {
                            combo.Add((nums[tempIndex], nums[i]));
                        }
                        else if (diff > k)
                        {
                            break;
                        }
                        tempIndex++;
                    }
                }

                return combo.Count;
            }
            else
            {
                return 0;
            }
        }


        [Test(Description = "https://leetcode.com/problems/k-diff-pairs-in-an-array/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("K-diff Pairs in an Array")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = FindPairs(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {

                    (2, (new int[]{ 3,1,4,1,5}, 2)),
                    (4, (new int[]{ 1,2,3,4,5}, 1)),
                };
            }
        }
    }
}

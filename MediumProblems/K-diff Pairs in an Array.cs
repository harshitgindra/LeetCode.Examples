using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    class K_diff_Pairs_in_an_Array
    {
        public int FindPairs(int[] nums, int k)
        {
            if (nums != null && nums.Length > 1)
            {
                Array.Sort(nums);

                IDictionary<int, int> dictionary = new Dictionary<int, int>();
                foreach (var item in nums)
                {
                    dictionary.TryAdd(item, 0);
                    dictionary[item]++;
                }

                int result = 0;
                foreach (var item in dictionary)
                {
                    dictionary[item.Key]--;

                    int valueRequired = item.Key + k;

                    if (dictionary.ContainsKey(valueRequired)
                        && dictionary[valueRequired] > 0)
                    {
                        result++;
                    }
                }

                return result;
            }

            return 0;
        }

        [Test(Description = "https://leetcode.com/problems/k-diff-pairs-in-an-array/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("K-diff Pairs in an Array")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = FindPairs(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (2, (new int[] {3, 1, 4, 1, 5}, 2)),
                    (4, (new int[] {1, 2, 3, 4, 5}, 1)),
                };
            }
        }
    }
}
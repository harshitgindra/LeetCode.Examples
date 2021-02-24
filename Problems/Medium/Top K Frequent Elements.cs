using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/top-k-frequent-elements/
    /// </summary>
    class Top_K_Frequent_Elements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            foreach (var item in nums)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            return dict.OrderByDescending(x => x.Value)
                .Take(k)
                .Select(x => x.Key)
                .ToArray();
        }
    }
}

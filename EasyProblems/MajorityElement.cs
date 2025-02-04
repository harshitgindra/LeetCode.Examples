using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.May
{
    /// <summary>
    /// https://leetcode.com/problems/majority-element/
    /// </summary>
    class MajorityElementTest
    {
        public int MajorityElement(int[] nums)
        {
            return nums
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .First().Key;
        }
    }
}
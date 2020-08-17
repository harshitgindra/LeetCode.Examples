using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.May
{
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

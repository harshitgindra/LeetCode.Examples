using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class _3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> ret = new List<IList<int>>();

            if (nums != null || nums.Length > 2)
            {
                Array.Sort(nums);
            }

            return ret;
        }

        private void SumUp(IList<IList<int>> result, IList<int> record, int currSum, int index)
        {

        }
    }
}

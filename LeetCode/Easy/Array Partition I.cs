using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Array_Partition_I
    {
        /// <summary>
        /// https://leetcode.com/problems/array-partition-i/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);

            int sum = 0;
            for (int i = 0; i < nums.Length; i = i + 2)
            {
                sum += nums[i];
            }

            return sum;
        }
    }
}

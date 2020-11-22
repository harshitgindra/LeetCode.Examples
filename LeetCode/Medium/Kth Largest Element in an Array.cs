using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/kth-largest-element-in-an-array/
    /// </summary>
    class Kth_Largest_Element_in_an_Array
    {
        public int FindKthLargest(int[] nums, int k)
        {
            int ret = -1;
            Array.Sort(nums);

            return nums[nums.Length - k];
        }
    }
}

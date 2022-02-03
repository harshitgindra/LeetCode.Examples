using System.Collections;
using System.Collections.Generic;

namespace Leetcode.Problems.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/4sum-ii/
    /// </summary>
    public class _4Sum_II
    {
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            int count = 0;
            //***
            //*** Mapping the sum of nums 1 and nums 2 to dictionary
            //***
            IDictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (var num1 in nums1)
            {
                foreach (var num2 in nums2)
                {
                    int temp = num1 + num2;

                    //***
                    //*** try to add temp to dictionary and increement the count
                    //***
                    dictionary.TryAdd(temp, 0);
                    dictionary[temp]++;
                }
            }

            foreach (var num3 in nums3)
            {
                foreach (var num4 in nums4)
                {
                    int temp = num3 + num4;
                    //***
                    //*** Checking if 0 - temp or (-temp) exists in dictionary
                    //***
                    if (dictionary.ContainsKey(-temp))
                    {
                        count+= dictionary[-temp];
                    }
                }
            }

            return count;
        }
    }
}
using System;
using System.Linq;

namespace LeetCode
{
    public class RemoveDuplicatesFromSortedArray
    {
        public RemoveDuplicatesFromSortedArray()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Remove Duplicates From Sorted Array");
            Console.WriteLine("----------------------------------------------------------");
        }

        public int RemoveDuplicates(int[] nums)
        {
            //int currentUniqueNumbers = 0;
            // int nextIndex = 1;

            int t = 0;
            int lastUpdated = 0;
            int? lastValue = null;
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] &&  nums[i] != lastValue)
                {
                    lastValue = nums[i];
                    lastUpdated = i;
                }
                else
                {
                    nums[lastUpdated] = lastValue.Value;
                    t++;
                }
            }

            return t;
        }
    }
}
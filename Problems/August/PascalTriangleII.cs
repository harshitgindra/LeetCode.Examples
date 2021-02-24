using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.August
{
    public class PascalTriangleII
    {
        public IList<int> GetRow(int rowIndex)
        {
            int[] nums = new int[1] { 1 };

            if (rowIndex != 0)
            {
                while (true)
                {
                    nums = Start(nums);

                    if (nums.Length == rowIndex + 1)
                    {
                        break;
                    }
                }
            }

            return nums.ToList();
        }

        private int[] Start(int[] nums)
        {
            int numLength = nums.Length;
            int[] newNums = new int[numLength + 1];
            //***
            //*** Fill all elements with first element of old array
            //***
            Array.Fill(newNums, nums[0]);

            for (int i = 0; i < numLength - 1; i++)
            {
                newNums[i + 1] = nums[i] + nums[i + 1];
            }

            return newNums;
        }
    }
}

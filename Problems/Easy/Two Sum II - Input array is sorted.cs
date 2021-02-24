using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Two_Sum_II___Input_array_is_sorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int[] ret = new int[2];
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                var diff = target - numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] == diff)
                    {
                        ret[0] = i+1;
                        ret[1] = j+1;
                        return ret;
                    }
                }
            }

            return ret;
        }
    }
}

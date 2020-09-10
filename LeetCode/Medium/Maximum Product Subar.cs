using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    public class Maximum_Product_Subar
    {
        public int MaxProduct2(int[] nums)
        {
            //int maxNum = nums[0];
            int allMultiply = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                allMultiply = allMultiply * nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int tempValue = allMultiply / nums[i];
                if (tempValue > allMultiply)
                {
                    allMultiply = tempValue;
                    break;
                }
            }

            return allMultiply;
        }

        public int MaxProduct(int[] nums)
        {
            int maxNum = nums[0];


            for (int i = 1; i < nums.Length; i++)
            {
                int innerCounter = i;
                int multiple = 1;
                while (innerCounter < nums.Length)
                {
                    multiple *= nums[innerCounter];
                    maxNum = Math.Max(multiple, maxNum);
                    innerCounter++;
                }

                if(maxNum > maxNum * nums[i])
                {

                }
                else
                {

                }
            }

            return maxNum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.August
{
    public class Sort_Array_By_Parity
    {
        public int[] SortArrayByParity(int[] A)
        {
            //***
            //*** Solution 1
            //***
            //var response = A.Where(x => x % 2 == 0).Concat(A.Where(x => x % 2 != 0));
            //return response.ToArray();

            //***
            //*** Solution 2
            //*** 
            int[] result = new int[A.Length];

            int startIndex = 0;
            int endIndex = A.Length - 1;
            foreach (var item in A)
            {
                if (item % 2 == 0)
                {
                    result[startIndex] = item;
                    startIndex++;
                }
                else
                {
                    result[endIndex] = item;
                    endIndex--;
                }
            }

            return result;
        }
    }
}

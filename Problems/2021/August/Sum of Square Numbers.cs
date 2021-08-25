using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.August
{
    /// <summary>
    /// https://leetcode.com/problems/sum-of-square-numbers/
    /// </summary>
    class Sum_of_Square_Numbers
    {
        public bool JudgeSquareSum(int c)
        {
            var upper = (int)Math.Sqrt(c);
            var lower = 0;

            while (lower <= upper)
            {
                //***
                //*** Applying the formula a*a + b*b = c
                //***
                var total = lower * lower + upper * upper;
                if (total == c)
                {
                    return true;
                }
                else if (total > c)
                {
                    //***
                    //*** Total greater than c
                    //*** decreement the upper value
                    //***
                    upper--;
                }
                else
                {
                    //***
                    //*** Total less than c
                    //*** increement the upper value
                    //***
                    lower++;
                }
            }
            return false;
        }
    }
}

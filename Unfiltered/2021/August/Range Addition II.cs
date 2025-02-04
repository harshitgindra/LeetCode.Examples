using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.August
{
    /// <summary>
    /// https://leetcode.com/problems/range-addition-ii/
    /// </summary>
    class Range_Addition_II
    {

        public int MaxCount(int m, int n, int[][] ops)
        {
            foreach (var item in ops)
            {
                m = Math.Min(m, item[0]);
                n = Math.Min(n, item[1]);
            }

            return m * n;
        }
    }
}

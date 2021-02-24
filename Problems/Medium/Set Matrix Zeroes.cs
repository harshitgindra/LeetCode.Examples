using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Set_Matrix_Zeroes
    {
        //https://leetcode.com/problems/set-matrix-zeroes/submissions/
        public void SetZeroes(int[][] matrix)
        {
            if (matrix != null)
            {
                HashSet<int> rows = new HashSet<int>();
                HashSet<int> cols = new HashSet<int>();
                for (int i = 0; i < matrix.Length; i++)
                {
                    var item = matrix[i];
                    for (int j = 0; j < item.Length; j++)
                    {
                        if (item[j] == 0)
                        {
                            rows.Add(i);
                            cols.Add(j);
                        }
                    }
                }

                var m = matrix[0].Length;
                foreach (var item in rows)
                {
                    for (int i = 0; i < m; i++)
                    {
                        matrix[item][i] = 0;
                    }
                }

                foreach (var item in cols)
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        matrix[i][item] = 0;
                    }
                }
            }
        }
    }
}

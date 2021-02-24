using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    public class Toeplitz_Matrix
    {
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            int xLength = matrix.Length;
            int yLength = matrix[0].Length;

            if (xLength == 1 || yLength == 1)
            {
                return true;
            }

            for (int k = 0; k < yLength; k++)
            {
                for (int i = 0; i < xLength - 1; i++)
                {
                    int num = matrix[i][k];
                    int x = i;
                    int y = k;
                    for (int j = 1; j < yLength; j++)
                    {
                        y++;
                        x++;
                        if (x < xLength && y < yLength && num != matrix[x][y])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}

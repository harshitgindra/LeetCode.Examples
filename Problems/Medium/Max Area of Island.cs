using System;

namespace LeetCode.Medium
{
    public class Max_Area_of_Island
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            int ret = 0;
            if (grid != null && grid.Length > 0)
            {
                int iMax = grid.Length;
                int jMax = grid[0].Length;

                for (int i = 0; i < iMax; i++)
                {
                    for (int j = 0; j < jMax; j++)
                    {
                        if (grid[i][j] == 1)
                        {
                            ret = Math.Max(ret, Calc(i, j, iMax, jMax, grid, 0));
                        }
                    }
                }
            }

            return ret;
        }

        private int Calc(int i, int j, int iMax, int jMax, int[][] grid, int total)
        {
            if (i < 0 || i >= iMax || j < 0 || j >= jMax || grid[i][j] == 0 || grid[i][j] == 2)
            {
                return total;
            }
            else
            {
                if (grid[i][j] == 1)
                {
                    grid[i][j] = 2;
                    total += 1;
                }

                total = Calc(i + 1, j, iMax, jMax, grid, total);
                total = Calc(i - 1, j, iMax, jMax, grid, total);
                total = Calc(i, j + 1, iMax, jMax, grid, total);
                total = Calc(i, j - 1, iMax, jMax, grid, total);
            }

            return total;
        }
    }
}
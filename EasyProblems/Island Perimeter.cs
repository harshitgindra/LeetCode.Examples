namespace LeetCode.EasyProblems
{
    public class Island_Perimeter
    {
        /// <summary>
        /// https://leetcode.com/problems/island-perimeter/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int IslandPerimeter(int[][] grid)
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
                            ret += Calc(i, j + 1, grid, iMax, jMax);
                            ret += Calc(i, j - 1, grid, iMax, jMax);
                            ret += Calc(i + 1, j, grid, iMax, jMax);
                            ret += Calc(i - 1, j, grid, iMax, jMax);
                        }
                    }
                }
            }

            return ret;
        }

        private int Calc(int i, int j, int[][] grid, int iMax, int jMax)
        {
            if (i < 0 || i >= iMax || j < 0 || j >= jMax || grid[i][j] == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
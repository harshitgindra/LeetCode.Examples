using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LeetCode.August
{
    public class RottingOranges
    {
        public int OrangesRotting(int[][] grid)
        {
            return Check(grid);
        }

        private int Check(int[][] grid)
        {
            int sum = 0;
            int gLength = grid.Length;
            for (int j = 0; j < gLength; j++)
            {
                var recLength = grid[j].Length;
                for (int i = 0; i < recLength; i++)
                {

                    if (grid[j][i] == 2)
                    {
                        bool elementAdded = false;
                        if (j + 1 < gLength && grid[j + 1][i] == 1)
                        {
                            grid[j + 1][i] = 2;
                            elementAdded = true;
                        }

                        if (i + 1 < recLength && grid[j][i + 1] == 1)
                        {
                            grid[j][i + 1] = 2;
                            elementAdded = true;
                        }

                        if (elementAdded)
                        {
                            sum++;
                        }
                    }
                }
            }

            if (sum == 0)
            {
                for (int j = 0; j < gLength; j++)
                {
                    var recLength = grid[j].Length;
                    for (int i = 0; i < recLength; i++)
                    {
                        if (grid[j][i] == 1)
                        {
                            return -1;
                        }
                    }
                }
            }



            return sum;
        }
    }
}

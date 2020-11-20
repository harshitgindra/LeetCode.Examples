namespace LeetCode.Medium
{
    public class Number_of_Islands
    {
        public int NumIslands(char[][] grid) {
        
            if (grid == null || grid.Length == 0) 
            {
                return 0;
            }
        
            int numberOfIslands = 0;
        
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    char v = grid[i][j];
                    if (v == '1')
                    {
                        numberOfIslands += sink(grid, i, j);
                    }
                } 
            }
        
            return numberOfIslands;
        }
    
        public int sink(char[][] grid, int i, int j)
        {
            if(i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0')
            {
                return 0;
            }
        
            grid[i][j] = '0';
            sink(grid, i, j + 1);
            sink(grid, i, j - 1);
            sink(grid, i + 1, j);
            sink(grid, i - 1, j);
            return 1;
        }
    }
}
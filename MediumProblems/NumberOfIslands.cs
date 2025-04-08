namespace LeetCode.MediumProblems
{
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            int islandCount = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            // Iterate through each cell in the grid
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // When we find a land cell ('1'), explore the entire island
                    if (grid[row][col] == '1')
                    {
                        islandCount++;
                        ExploreIsland(grid, row, col);
                    }
                }
            }

            return islandCount;
        }

        private void ExploreIsland(char[][] grid, int row, int col)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            // Check boundary conditions and if current cell is land
            if (row < 0 || col < 0 || row >= rows || col >= cols || grid[row][col] == '0')
            {
                return;
            }

            // Mark current cell as visited
            grid[row][col] = '0';

            // Explore in all four directions (up, right, down, left)
            ExploreIsland(grid, row + 1, col); // Down
            ExploreIsland(grid, row - 1, col); // Up
            ExploreIsland(grid, row, col + 1); // Right
            ExploreIsland(grid, row, col - 1); // Left
        }
        
        [Test(Description = "https://leetcode.com/problems/number-of-islands/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Number of Islands")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, char[][] Input) item)
        {
            var response = this.NumIslands(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, char[][] Input)> Input =>
            new List<(int Output, char[][] Input)>()
            {
                (1, [
                    ['1', '1', '1', '1', '0'],
                    ['1', '1', '0', '1', '0'],
                    ['1', '1', '0', '0', '0'],
                    ['0', '0', '0', '0', '0']
                ])
            };
    }
}
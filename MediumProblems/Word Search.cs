namespace LeetCode.MediumProblems
{
    public class WordSearch
    {
        // Time: O(m × n × 3^k)
        // Space: O(k)
        public bool Exist(char[][] board, string word)
        {
            // Check for empty board or empty word
            if (board == null || board.Length == 0 || string.IsNullOrEmpty(word))
                return false;

            int rows = board.Length;
            int cols = board[0].Length;

            // Iterate through each cell in the board
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Start DFS from cells matching the first character
                    if (board[i][j] == word[0] && Dfs(board, i, j, word, 0))
                        return true;
                }
            }

            return false;
        }

        private bool Dfs(char[][] board, int row, int col, string word, int index)
        {
            // Base case: entire word found
            if (index == word.Length - 1)
                return true;

            // Temporarily mark current cell as visited
            char original = board[row][col];
            board[row][col] = '#'; // Using '#' as visited marker

            // Define directions: up, right, down, left
            int[] dirs = { -1, 0, 1, 0, -1 };

            // Explore all four directions
            for (int d = 0; d < 4; d++)
            {
                int newRow = row + dirs[d];
                int newCol = col + dirs[d + 1];

                // Check boundaries and character match
                if (newRow >= 0 && newRow < board.Length &&
                    newCol >= 0 && newCol < board[0].Length &&
                    board[newRow][newCol] == word[index + 1])
                {
                    // Recursive DFS call for next character
                    if (Dfs(board, newRow, newCol, word, index + 1))
                        return true;
                }
            }

            // Backtrack: restore original character
            board[row][col] = original;
            return false;
        }

        [Test(Description = "https://leetcode.com/problems/word-search/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Word Search")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, (char[][], string) Input) item)
        {
            var response = Exist(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(bool Output, (char[][], string) Input)> Input
        {
            get
            {
                return new List<(bool Output, (char[][], string) Input)>()
                {
                    (true, (new char[][]
                    {
                        new char[] { 'A', 'B', 'C', 'E' },
                        new char[] { 'S', 'F', 'C', 'S' },
                        new char[] { 'A', 'D', 'E', 'E' },
                    }, "ABCCED")),
                };
            }
        }
    }
}
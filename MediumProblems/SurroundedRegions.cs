namespace LeetCode.MediumProblems;

public class SurroundedRegions
{
    public void Solve(char[][] board)
    {
        // Handle edge cases
        if (board == null || board.Length == 0) return;

        int rows = board.Length;
        int cols = board[0].Length;

        // Step 1: Mark all 'O's connected to borders as safe ('T')
        // Check first and last column
        for (int row = 0; row < rows; row++)
        {
            MarkSafeRegion(board, row, 0);
            MarkSafeRegion(board, row, cols - 1);
        }

        // Check first and last row
        for (int col = 0; col < cols; col++)
        {
            MarkSafeRegion(board, 0, col);
            MarkSafeRegion(board, rows - 1, col);
        }

        // Step 2: Convert all remaining 'O's to 'X' and restore 'T's to 'O'
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (board[row][col] == 'O')
                {
                    // This 'O' is surrounded, so capture it
                    board[row][col] = 'X';
                }
                else if (board[row][col] == 'T')
                {
                    // This was a safe 'O', restore it
                    board[row][col] = 'O';
                }
            }
        }
    }

    private void MarkSafeRegion(char[][] board, int row, int col)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        // Base case: out of bounds or not an 'O'
        if (row < 0 || row >= rows || col < 0 || col >= cols || board[row][col] != 'O')
        {
            return;
        }

        // Mark this cell as safe
        board[row][col] = 'T';

        // Check all four adjacent cells
        MarkSafeRegion(board, row + 1, col); // Down
        MarkSafeRegion(board, row - 1, col); // Up
        MarkSafeRegion(board, row, col + 1); // Right
        MarkSafeRegion(board, row, col - 1); // Left
    }


    [Test(Description = "https://leetcode.com/problems/surrounded-regions/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Surrounded Regions")]
    [TestCaseSource(nameof(Input))]
    public void Test1((char[][] Output, char[][] Input) item)
    {
        this.Solve(item.Input);
        Assert.That(item.Input, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(char[][] Output, char[][] Input)> Input =>
        new List<(char[][] Output, char[][] Input)>()
        {
            ([['X', 'X', 'X', 'X'], ['X', 'X', 'X', 'X'], ['X', 'X', 'X', 'X'], ['X', 'O', 'X', 'X']],
                [['X', 'X', 'X', 'X'], ['X', 'O', 'O', 'X'], ['X', 'X', 'O', 'X'], ['X', 'O', 'X', 'X']])
        };
}
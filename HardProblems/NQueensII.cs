namespace LeetCode.HardProblems;

/// <summary>
/// https://leetcode.com/problems/n-queens-ii/
/// </summary>
public class NQueensII
{
    private int count = 0; // Total number of valid solutions

    public int TotalNQueens(int n) {
        if (n == 0) return 0;
        bool[] columns = new bool[n];
        bool[] posDiag = new bool[2 * n - 1]; // Tracks positive slope diagonals (row - col + n - 1)
        bool[] negDiag = new bool[2 * n - 1]; // Tracks negative slope diagonals (row + col)
        Backtrack(0, columns, posDiag, negDiag, n);
        return count;
    }

    private void Backtrack(int row, bool[] columns, bool[] posDiag, bool[] negDiag, int n) {
        if (row == n) {
            count++;
            return;
        }

        for (int col = 0; col < n; col++) {
            int posIndex = row - col + n - 1; // Shift to avoid negative indices
            int negIndex = row + col;

            if (columns[col] || posDiag[posIndex] || negDiag[negIndex]) {
                continue; // Skip attacked positions
            }

            // Place queen and mark attacks
            columns[col] = true;
            posDiag[posIndex] = true;
            negDiag[negIndex] = true;

            Backtrack(row + 1, columns, posDiag, negDiag, n);

            // Remove queen and unmark attacks (backtrack)
            columns[col] = false;
            posDiag[posIndex] = false;
            negDiag[negIndex] = false;
        }
    }
    
    [Test(Description = "https://leetcode.com/problems/n-queens-ii/")]
    [Category("Hard")]
    [Category("LeetCode")]
    [Category("N Queens II")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int Input) item)
    {
        var response = TotalNQueens(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int Input)> Input =>
        new List<(int Output, int Input)>()
        {
            (2, 4),
        };
}
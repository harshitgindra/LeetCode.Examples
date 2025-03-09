namespace LeetCode.Problems._2021.August
{
    class Sudoku_Solver
    {
        private char[] _nums = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        /// <summary>
        /// https://leetcode.com/problems/sudoku-solver/
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[][] board)
        {
            if (board != null)
            {
                Solve(board);
            }
        }

        private bool Solve(char[][] board)
        {
            //***
            //*** Loop through all the spaces in the board
            //***
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        //***
                        //*** In an empty space, iterate through all possible inputs and validate the board
                        //***
                        foreach (var num in _nums)
                        {
                            //***
                            //*** Check if row, column and box is still valid if we add the num
                            //***
                            if (_IsRowValid(board, i, num)
                                && _IsColumnValid(board, j, num)
                                && _IsBoxValid(board, i, j, num))
                            {
                                //***
                                //*** Add the new number to empty space and check the board from start
                                //***
                                board[i][j] = num;
                                //***
                                //*** If the board is valid, we have entered the right value
                                //*** If not, reset the space to empty and try next number
                                //***
                                if (Solve(board))
                                {
                                    return true;
                                }
                                else
                                {
                                    board[i][j] = '.';
                                }
                            }
                        }

                        return false;
                    }
                }
            }
            return true;
        }

        private bool _IsRowValid(char[][] board, int rowIndex, char num)
        {
            //***
            //*** Iterate through all entries in row and check if num already exists
            //***
            var row = board[rowIndex];
            return !row.Any(x => x == num);
        }

        private bool _IsColumnValid(char[][] board, int columnIndex, char num)
        {
            //***
            //*** Iterate through all entries in column and check if num already exists
            //***
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][columnIndex] == num)
                {
                    return false;
                }
            }
            return true;
        }

        private bool _IsBoxValid(char[][] board, int rowIndex, int columnIndex, char num)
        {
            //***
            //*** Get the range if row index and column index for the box
            //***
            var rowRange = _GetRangeForBox(rowIndex);
            var colRange = _GetRangeForBox(columnIndex);
            //***
            //*** Iterate through all entries in the box and check if num already exists
            //***
            for (int i = rowRange.Lower; i <= rowRange.Upper; i++)
            {
                for (int j = colRange.Lower; j <= colRange.Upper; j++)
                {
                    if (board[i][j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private (int Lower, int Upper) _GetRangeForBox(int i)
        {
            if (i < 3)
            {
                return (0, 2);
            }
            if (i < 6)
            {
                return (3, 5);
            }
            if (i < 9)
            {
                return (6, 8);
            }
            return default;
        }

        [Test(Description = "https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Maximum Product of Splitted Binary Tree")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, char[][] Input) item)
        {
            this.SolveSudoku(item.Input);
        }

        public static IEnumerable<(int Output, char[][] Input)> Input
        {
            get
            {
                return new List<(int Output, char[][] Input)>()
                {
                    (110,
                    new char[][]{
                        new char[]{'5','3','.','.','7','.','.','.','.'},
                        new char[]{'6','.','.','1','9','5','.','.','.'},
                        new char[]{'.','9','8','.','.','.','.','6','.'},
                        new char[]{'8','.','.','.','6','.','.','.','3'},
                        new char[]{'4','.','.','8','.','3','.','.','1'},
                        new char[]{'7','.','.','.','2','.','.','.','6'},
                        new char[]{'.','6','.','.','.','.','2','8','.'},
                        new char[]{'.','.','.','4','1','9','.','.','5'},
                        new char[]{'.','.','.','.','8','.','.','7','9'} })
                };
            }
        }
    }
}

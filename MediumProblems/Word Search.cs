namespace LeetCode.MediumProblems
{
    public class Word_Search
    {
        public bool Exist(char[][] board, string word)
        {
            int iMax = board.Length;
            int jMax = board[0].Length;

            for (int i = 0; i < iMax; i++)
            {
                for (int j = 0; j < jMax; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        if (word.Length == 1)
                        {
                            return true;
                        }
                        else if (StartSearching(i, j, iMax, jMax, 0, board, word))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool StartSearching(int i, int j, int iMax, int jMax, int current, char[][] board, string word)
        {
            if (current == word.Length)
            {
                return true;
            }
            else if (i < 0 || i >= iMax || j < 0 || j >= jMax || board[i][j] == '*')
            {
                return false;
            }
            else
            {
                if (board[i][j] == word[current])
                {
                    board[i][j] = '*';
                    if (StartSearching(i + 1, j, iMax, jMax, current + 1, board, word))
                    {
                        return true;
                    }

                    if (StartSearching(i - 1, j, iMax, jMax, current + 1, board, word))
                    {
                        return true;
                    }

                    if (StartSearching(i, j + 1, iMax, jMax, current + 1, board, word))
                    {
                        return true;
                    }

                    if (StartSearching(i, j - 1, iMax, jMax, current + 1, board, word))
                    {
                        return true;
                    }

                    board[i][j] = word[current];
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/maximal-rectangle/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("maximal rectangle")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, char[][] Input) item)
        {
            var response = Exist(item.Input, "AA");
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, char[][] Input)> Input
        {
            get
            {
                return new List<(int Output, char[][] Input)>()
                {
                    (4, new char[][]
                    {
                        new char[] {'A','A'},
                    }),
                    (4, new char[][]
                    {
                        new char[] {'A', 'B', 'C', 'E'},
                        new char[] {'S', 'F', 'C', 'S'},
                        new char[] {'A', 'D', 'E', 'E'},
                    }),
                };
            }
        }
    }
}
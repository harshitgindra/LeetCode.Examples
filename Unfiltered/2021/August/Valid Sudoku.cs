namespace LeetCode.Problems._2021.August
{
    class Valid_Sudoku
    {
        //https://leetcode.com/problems/valid-sudoku/
        public bool IsValidSudoku(char[][] board)
        {
            bool result = true;
            IDictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
            IDictionary<int, HashSet<char>> columns = new Dictionary<int, HashSet<char>>();
            IDictionary<int, HashSet<char>> boxes = new Dictionary<int, HashSet<char>>();

            for (int i = 0; i < board.Length; i++)
            {
                var item = board[i];

                for (int j = 0; j < item.Length; j++)
                {
                    var field = board[i][j];

                    if (field != '.')
                    {

                        if (rows.ContainsKey(i))
                        {
                            if (!rows[i].Add(field))
                            {
                                result = false;
                                break;
                            }
                        }
                        else
                        {
                            rows.Add(i, new HashSet<char>() { field });
                        }

                        if (columns.ContainsKey(j))
                        {
                            if (!columns[j].Add(field))
                            {
                                result = false;
                                break;
                            }
                        }
                        else
                        {
                            columns.Add(j, new HashSet<char>() { field });
                        }

                        int boxNum = GetBox(i, j);
                        if (boxes.ContainsKey(boxNum))
                        {
                            if (!boxes[boxNum].Add(field))
                            {
                                result = false;
                                break;
                            }
                        }
                        else
                        {
                            boxes.Add(boxNum, new HashSet<char>() { field });
                        }
                    }
                }

                if (!result)
                {
                    break;
                }
            }

            return result;
        }


        private int GetBox(int i, int j)
        {
            if (i < 3 && j < 3)
            {
                return 1;
            }

            if (i < 3 && j > 2 && j < 6)
            {
                return 2;
            }

            if (i < 3 && j > 5 && j < 9)
            {
                return 3;
            }

            if (2 < i && i < 6 && j < 3)
            {
                return 4;
            }

            if (2 < i && i < 6 && j > 2 && j < 6)
            {
                return 5;
            }

            if (2 < i && i < 6 && j > 5 && j < 9)
            {
                return 6;
            }

            if (5 < i && i < 9 && j < 3)
            {
                return 7;
            }

            if (5 < i && i < 9 && j > 2 && j < 6)
            {
                return 8;
            }

            if (5 < i && i < 9 && j > 5 && j < 9)
            {
                return 9;
            }
            return 0;
        }
    }
}

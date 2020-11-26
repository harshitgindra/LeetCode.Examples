using System.Collections.Generic;

namespace LeetCode.Hard
{
    /// <summary>
    /// https://leetcode.com/problems/word-search-ii/
    /// </summary>
    public class Word_Search_II
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            int iMax = board.Length;
            int jMax = board[0].Length;
            var result = new List<string>();
            foreach (var word in words)
            {
                if (Start(iMax, jMax, board, word))
                {
                    result.Add(word);
                }
            }
            return result;
        }

        private bool Start(int iMax, int jMax, char[][] board, string word)
        {
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
                        board[i][j] = word[current];
                        return true;
                    }

                    if (StartSearching(i - 1, j, iMax, jMax, current + 1, board, word))
                    {
                        board[i][j] = word[current];   
                        return true;
                    }

                    if (StartSearching(i, j + 1, iMax, jMax, current + 1, board, word))
                    {
                        board[i][j] = word[current];
                        return true;
                    }

                    if (StartSearching(i, j - 1, iMax, jMax, current + 1, board, word))
                    {
                        board[i][j] = word[current];
                        return true;
                    }

                    board[i][j] = word[current];
                }
            }

            return false;
        }
    }
}
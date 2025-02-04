using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    class WordSearchII
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            IDictionary<char, IList<(int X, int Y)>> dict = new Dictionary<char, IList<(int X, int Y)>>();

            for (int i = 0; i < board.Length; i++)
            {
                var row = board[i];
                for (int j = 0; j < row.Length; j++)
                {
                    if (!dict.ContainsKey(board[i][j]))
                    {
                        dict.Add(board[i][j], new List<(int, int)>());
                    }

                    dict[board[i][j]].Add((i, j));
                }
            }

            IList<string> ret = words.ToList();
            foreach (var item in words)
            {
                int x, y = default;
                foreach (var c in item)
                {
                    if (!dict.ContainsKey(c))
                    {
                        ret.Remove(item);
                        break;
                    }
                    else
                    {
                        var coordinates = dict[c];
                    }
                }
            }

            return null;
        }

        [Test(Description = "https://leetcode.com/problems/word-search-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Word Search II")]
        [TestCaseSource("Input")]
        public void Test1((IList<string> Output, (char[][], string[]) Input) item)
        {
            var response = FindWords(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(IList<string> Output, (char[][], string[]) Input)> Input
        {
            get
            {
                return new List<(IList<string> Output, (char[][], string[]) Input)>()
                {

                    (new List<string>(){"eat","oath" }, (
                    new char[][]
                    {
new char[]{ 'o', 'a', 'a', 'n' },
new char[]{ 'e','t','a','e' },
new char[]{ 'i','h','k','r' },
new char[]{ 'i','f','l','v' },
                    },new string[]{ "oath", "pea", "eat", "rain" }

                    ))
                };
            }
        }
    }
}

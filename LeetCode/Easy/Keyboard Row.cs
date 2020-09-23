using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LeetCode.Easy
{
    class Keyboard_Row
    {
        private IDictionary<char, int> _letters = new Dictionary<char, int>()
        {
            {'q', 1},
            {'w', 1},
            {'e', 1},
            {'r', 1},
            {'t', 1},
            {'y', 1},
            {'u', 1},
            {'i', 1},
            {'o', 1},
            {'p', 1},

            {'a', 2},
            {'s', 2},
            {'d', 2},
            {'f', 2},
            {'g', 2},
            {'h', 2},
            {'j', 2},
            {'k', 2},
            {'l', 2},

            {'z', 3},
            {'x', 3},
            {'c', 3},
            {'v', 3},
            {'b', 3},
            {'n', 3},
            {'m', 3},
        };

        public string[] FindWords(string[] words)
        {
            List<string> result = new List<string>();
            foreach (var item in words)
            {
                var tempItem = item.ToLower();
                result.Add(item);
                for (int i = 0; i < item.Length - 1; i++)
                {
                    if (_letters[tempItem[i]] != _letters[tempItem[i + 1]])
                    {
                        result.Remove(item);
                        break;
                    }
                }
            }

            return result.ToArray();
        }

        [Test(Description = "https://leetcode.com/problems/keyboard-row/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Keyboard Row")]
        [TestCaseSource("Input")]
        public void Test1((string[] Output, string[] Input) item)
        {
            var response = FindWords(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string[] Output, string[] Input)> Input
        {
            get
            {
                return new List<(string[] Output, string[] Input)>()
                {

                    (new string[]{"Alaska", "Dad" }, new string[]{"Hello", "Alaska", "Dad", "Peace" }),
                };
            }
        }
    }
}

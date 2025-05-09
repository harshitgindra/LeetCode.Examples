﻿

namespace LeetCode.EasyProblems
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
        [Category("LeetCode")]
        [Category("Keyboard Row")]
        [TestCaseSource(nameof(Input))]
        public void Test1((string[] Output, string[] Input) item)
        {
            var response = FindWords(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(string[] Output, string[] Input)> Input
        {
            get
            {
                return new List<(string[] Output, string[] Input)>()
                {

                    (["Alaska", "Dad"], ["Hello", "Alaska", "Dad", "Peace"]),
                };
            }
        }
    }
}

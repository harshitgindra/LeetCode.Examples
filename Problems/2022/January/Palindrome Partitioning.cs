using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Leetcode.Problems._2022.January
{
    public class Palindrome_Partitioning
    {
        private IList<IList<string>> _result;

        public IList<IList<string>> Partition(string s)
        {
            _result = new List<IList<string>>();
            Helper(s, 0, new List<string>());
            return _result;
        }

        private void Helper(string s, int index, IList<string> strs)
        {
            if (index == s.Length && strs.Any())
            {
                _result.Add(strs.ToList());
            }
            else
            {
                string tempStr = "";
                for (int i = index; i < s.Length; i++)
                {
                    tempStr += s[i];

                    if (IsPalindrome(tempStr))
                    {
                        strs.Add(tempStr);
                        Helper(s, i + 1, strs);
                        strs.RemoveAt(strs.Count - 1);
                    }
                }
            }
        }

        bool IsPalindrome(string str)
        {
            if (str.Length == 1)
            {
                return true;
            }

            int i = 0;
            while (i <= (str.Length / 2))
            {
                if (str[i] == str[str.Length - 1 - i])
                {
                    i++;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/palindrome-partitioning/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Palindrome Partitioning")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, string Input) item)
        {
            var response = Partition(item.Input);
            // Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, string Input)> Input
        {
            get
            {
                return new List<(bool Output, string Input)>()
                {
                    (true, ("aab")),
                };
            }
        }
    }
}
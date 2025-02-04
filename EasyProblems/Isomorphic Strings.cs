using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    class Isomorphic_Strings
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t))
            {
                return true;
            }
            else if (s.Length != t.Length)
            {
                return false;
            }
            else
            {
                if (Compare(s, t))
                {
                    return Compare(t, s);
                }
                else
                {
                    return false;
                }
            }
        }

        private bool Compare(string s, string t)
        {
            IDictionary<char, char> dict = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    if (dict[s[i]] != t[i])
                    {
                        return false;
                    }
                }
                else
                {
                    dict.Add(s[i], t[i]);
                }
            }
            return true;
        }

        [Test(Description = "https://leetcode.com/problems/isomorphic-strings/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Isomorphic Strings")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (string, string) Input) item)
        {
            var response = IsIsomorphic(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(bool Output, (string, string) Input)>()
                {

                    (true, ("egg", "add")),
                };
            }
        }
    }
}

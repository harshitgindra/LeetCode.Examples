using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/reformat-the-string/
    /// </summary>
    class Reformat_The_String
    {
        public string Reformat(string s)
        {
            var dict = new Dictionary<bool, List<char>>
            {
                { true, new List<char>() },
                { false, new List<char>() }
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    dict[true].Add(s[i]);
                }
                else
                {
                    dict[false].Add(s[i]);
                }
            }

            if (Math.Abs(dict[true].Count - dict[false].Count) < 2)
            {
                if (dict[true].Count > dict[false].Count)
                {
                    return Build(dict[true], dict[false]);
                }
                else
                {
                    return Build(dict[false], dict[true]);
                }
            }
            else
            {
                return "";
            }
        }

        private string Build(List<char> a, List<char> b)
        {
            string str = "";
            for (int i = 0; i < a.Count; i++)
            {
                str += a[i];

                if (i < b.Count)
                {
                    str += b[i];
                }
            }

            return str;
        }
    }
}

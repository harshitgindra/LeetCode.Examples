using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/backspace-string-compare/
    /// </summary>
    class Backspace_String_Compare
    {
        public bool BackspaceCompare(string S, string T)
        {
            S = Parse(S);
            T = Parse(T);

            return S == T;
        }

        private string Parse(string str)
        {
            List<char> ret = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '#')
                {
                    if (ret.Count > 1)
                    {
                        ret.RemoveAt(ret.Count - 1);
                    }
                }
                else
                {
                    ret.Add(str[i]);
                }
            }

            return string.Join("", ret);
        }
    }
}

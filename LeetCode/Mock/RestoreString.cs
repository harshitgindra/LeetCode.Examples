using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Mock
{
    class RestoreStringTest
    {
        /// <summary>
        /// https://leetcode.com/problems/shuffle-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public string RestoreString(string s, int[] indices)
        {

            SortedDictionary<int, char> dict = new SortedDictionary<int, char>();

            for (int i = 0; i < indices.Length; i++)
            {
                dict.Add(indices[i], s[i]);
            }

            return string.Join("", dict.Values);
        }
    }
}

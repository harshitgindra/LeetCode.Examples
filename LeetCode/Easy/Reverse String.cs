using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    public class Reverse_String
    {
        public void ReverseString(char[] s)
        {
            int startIndex = 0;
            int endIndex = s.Length - 1;
            for (int i = 0; i < s.Length / 2; i++)
            {
                var currSpace = s[startIndex];
                s[startIndex] = s[endIndex];
                s[endIndex] = currSpace;
                startIndex++;
                endIndex++;
            }
        }
    }
}

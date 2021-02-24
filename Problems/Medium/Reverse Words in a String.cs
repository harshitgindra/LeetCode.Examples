using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    public class Reverse_Words_in_a_String
    {
        public string ReverseWords(string s)
        {
            var wordArray = s.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string returnValue = "";
            for (int i = wordArray.Length - 1; i >= 0; i--)
            {
                returnValue += $"{wordArray[i].Trim()} ";
            }

            return returnValue.TrimEnd();
        }
    }
}

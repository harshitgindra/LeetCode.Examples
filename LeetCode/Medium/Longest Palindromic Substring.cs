using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Longest_Palindromic_Substring
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return default;
            }
            if(s.Length == 1)
            {
                return s;
            }
            else
            {
                var arry = s.ToCharArray();
                Array.Reverse(arry);
                string sReverse = new string(arry);
                string returnValue = $"{s[0]}";

                for (int sIndex = 0; sIndex < s.Length - returnValue.Length; sIndex++)
                {
                    for (int length = s.Length - sIndex; length > returnValue.Length; length--)
                    {
                        var subStr = s.Substring(sIndex, length);
                        if (sReverse.Contains(subStr) && IsPalindrome(subStr))
                        {
                            returnValue = subStr;
                            break;
                        }
                    }
                }

                return returnValue;
            }
        }


        public bool IsPalindrome(string str)
        {
            if (str.Length == 1 || str.Length == 0) return true;
            return str[0] == str[^1] && IsPalindrome(str.Substring(1, str.Length - 2));
        }

        [Test(Description = "https://leetcode.com/problems/longest-palindromic-substring/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Longest Palindromic Substring")]
        [TestCaseSource("Input")]
        public void Test1((string Output, string Input) item)
        {
            var response = LongestPalindrome(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, string Input)> Input
        {
            get
            {
                return new List<(string Output, string Input)>()
                {
                    ("bab",                    "babad"),
                    ("bb",                    "cbbd")
                };
            }
        }
    }
}

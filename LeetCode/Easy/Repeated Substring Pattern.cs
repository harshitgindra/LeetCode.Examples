using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    class Repeated_Substring_Pattern
    {
        public bool RepeatedSubstringPattern(string s)
        {
            for (int i = 2; i <= s.Length; i++)
            {
                if (s.Length % i != 0)
                {
                    continue;
                }

                int length = s.Length / i;
                int j = length;

                string part = s.Substring(0, length);
                bool valid = true;
                while (j < s.Length)
                {
                    if (part == s.Substring(j, length))
                    {
                        j += length;
                        continue;
                    }

                    valid = false;
                    break;
                }

                if (valid)
                {
                    return true;
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/repeated-substring-pattern/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Repeated Substring Pattern")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, string Input) item)
        {
            var response = RepeatedSubstringPattern(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, string Input)> Input
        {
            get
            {
                return new List<(bool Output, string Input)>()
                {
                    (false, "ab"),
                    (true, "abab"),
                    (false, "aba"),
                };
            }
        }
    }
}

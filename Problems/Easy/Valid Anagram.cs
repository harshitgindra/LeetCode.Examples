using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Easy
{
    class Valid_Anagram
    {
        public bool IsAnagram(string s, string t)
        {
            return string.Concat(s.OrderBy(c => c)) == String.Concat(t.OrderBy(c => c));
        }

        [Test(Description = "https://leetcode.com/problems/valid-anagram/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Valid Anagram")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (string, string) Input) item)
        {
            var response = IsAnagram(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(bool Output, (string, string) Input)>()
                {

                    (true, ("anagram", "nagaram")),
                    (false, ("rat", "car")),
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Hard
{
    class Minimum_Window_Substring
    {
        public string MinWindow(string s, string t)
        {
            return "";
        }

        [Test(Description = "https://leetcode.com/problems/minimum-window-substring/")]
        [Category("Hard")]
        [Category("Leetcode")]
        [Category("Best Time to Buy and Sell Stock IV")]
        [TestCaseSource("Input")]
        public void Test1((string Output, (string, string) Input) item)
        {
            var response = MinWindow(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(string Output, (string, string) Input)>()
                {

                    ("BANC",( "ADOBECODEBANC", "ABC")),
                };
            }
        }
    }
}

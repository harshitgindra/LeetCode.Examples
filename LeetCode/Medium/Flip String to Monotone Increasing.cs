using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Flip_String_to_Monotone_Increasing
    {
        public int MinFlipsMonoIncr(string S)
        {
            bool secondLoop = false;
            foreach (var item in S)
            {

            }

            char[] a = new char[1];
            string.Join("",a);
        }


        [Test(Description = "https://leetcode.com/problems/flip-string-to-monotone-increasing/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Flip String to Monotone Increasing")]
        [TestCaseSource("Input")]
        public void Test1((int Output, string Input) item)
        {
            var response = MinFlipsMonoIncr(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {

                    (1,"00110"),
                };
            }
        }
    }
}

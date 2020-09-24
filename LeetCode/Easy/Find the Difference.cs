using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Find_the_Difference
    {
        public char FindTheDifference(string s, string t)
        {
            var sArry = s.ToCharArray();
            Array.Sort(sArry);

            var tArry = t.ToCharArray();
            Array.Sort(tArry);

            char returnValue = tArry[tArry.Length - 1];

            for (int i = 0; i < s.Length; i++)
            {
                if(sArry[i] != tArry[i])
                {
                    returnValue = tArry[i];
                    break;
                }
            }
            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/find-the-difference/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Find the Difference")]
        [TestCaseSource("Input")]
        public void Test1((char Output, (string, string) Input) item)
        {
            var response = FindTheDifference(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(char Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(char Output, (string, string) Input)>()
                {

                    ('e', ("abcd", "abcde")),
                };
            }
        }
    }
}

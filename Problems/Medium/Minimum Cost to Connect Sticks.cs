using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Medium
{
    class Minimum_Cost_to_Connect_Sticks
    {
        public int ConnectSticks(int[] sticks)
        {
            int returnValue = 0;
            if (sticks != null && sticks.Length > 1)
            {
                Array.Sort(sticks);
                int prevNumber = sticks[0];
                for (int i = 1; i < sticks.Length; i++)
                {
                    prevNumber = sticks[i] + prevNumber;
                    returnValue = prevNumber + returnValue;
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/super-palindromes/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Super Palindromes")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = ConnectSticks(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (4, new int[]{1,8,3,5}),
                };
            }
        }
    }
}

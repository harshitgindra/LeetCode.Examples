﻿

namespace LeetCode.MediumProblems
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
        [TestCaseSource(nameof(Input))]
        [Ignore("")]
        public void Test1((int Output, int[] Input) item)
        {
            // var response = ConnectSticks(item.Input);
            // Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (4, [1,8,3,5]),
            };
    }
}

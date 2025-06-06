﻿

namespace LeetCode.EasyProblems
{
    class Consecutive_Characters
    {
        public int MaxPower(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            if (s.Length == 1)
            {
                return 1;
            }

            int returnValue = 1;
            char prevValue = s[0];
            int count = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == prevValue)
                {
                    returnValue++;
                }
                else
                {
                    prevValue = s[i];
                    count = Math.Max(returnValue, count);
                    returnValue = 1;
                }
            }

            count = Math.Max(returnValue, count);
            return count;
        }

        [Test(Description = "https://leetcode.com/problems/consecutive-characters/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Consecutive Characters")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, string Input) item)
        {
            var response = MaxPower(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, string Input)> Input =>
            new List<(int Output, string Input)> { (2, "leetcode"),
                (2, "cc")};
    }
}

using System.Collections.Generic;
using NUnit.Framework;

namespace Leetcode.Problems.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/count-and-say/
    /// </summary>
    public class Count_and_Say
    {
        public string CountAndSay(int n)
        {
            string result = "1";
            // Run the for loop until n - 1
            for (int i = 1; i < n; i++)
            {
                result = _Helper(result);
            }

            return result;
        }

        private string _Helper(string previous)
        {
            int count = 1;
            char prev = previous[0];
            string result = "";
            for (int i = 1; i < previous.Length; i++)
            {
                if (previous[i] == prev)
                {
                    // Previous and current char are the same
                    // Increment the counter
                    count++;
                }
                else
                {
                    // Characters don't match
                    // append the count and prev char to result
                    // and reset the counter and prev char
                    result += $"{count}{prev}";
                    count = 1;
                    prev = previous[i];
                }
            }

            // append the last set of char and count to result and return
            result += $"{count}{prev}";
            return result;
        }

        [Test(Description = "https://leetcode.com/problems/count-and-say/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Count and Say")]
        [TestCaseSource("Input")]
        public void Test1((string Output, int Input) item)
        {
            var response = CountAndSay(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, int Input)> Input
        {
            get
            {
                return new List<(string Output, int Input)>()
                {
                    ("1211", 4),
                };
            }
        }
    }
}
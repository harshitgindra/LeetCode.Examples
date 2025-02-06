using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    public class LongestPalindromeTest
    {
        public int LongestPalindrome(string s)
        {
            int maxLength = s.Length;

            if (maxLength == 1)
            {
                return 1;
            }

            s = string.Concat(s.OrderBy(c => c));

            int startIndex = 0;
            // int nextIndex = 1;
            int returnValue = 0;

            while (startIndex < maxLength)
            {
                int nextIndex = startIndex + 1;
                if (nextIndex != maxLength && s[startIndex] == s[nextIndex])
                {
                    startIndex += 2;
                    //nextIndex += 2;
                    returnValue += 2;
                }
                else
                {
                    startIndex++;
                    //nextIndex++;
                    if (returnValue % 2 != 0) continue;
                    returnValue++;
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/longest-palindromic-substring/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Longest Palindrome")]
        [TestCaseSource("Input")]
        public void Test1((string Output, string Input) item)
        {
            var response = LongestPalindrome(item.Input);
            ClassicAssert.AreEqual(item.Output, response.ToString());
        }

        public static IEnumerable<(string Output, string Input)> Input
        {
            get
            {
                return new List<(string Output, string Input)>()
                {
                    ("bab", "babad"),
                    ("bb", "cbbd")
                };
            }
        }
    }
}
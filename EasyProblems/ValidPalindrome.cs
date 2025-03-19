

namespace LeetCode
{
    public class ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            if (s == null || s.Length < 2)
            {
                return true;
            }
            else
            {
                int sIndex = 0;
                int eIndex = s.Length - 1;
                while (sIndex < s.Length)
                {
                    if (!char.IsLetterOrDigit(s[sIndex]))
                    {
                        sIndex++;
                    } else if (!char.IsLetterOrDigit(s[eIndex]))
                    {
                        eIndex--;
                    }
                    else
                    {
                        char c1 = s[sIndex];
                        char c2 = s[eIndex];
                        if (char.ToUpper(s[sIndex]) != char.ToUpper(s[eIndex]))
                        {
                            return false;
                        }

                        sIndex++;
                        eIndex--;
                    }
                }
            }

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/valid-palindrome/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Valid Palindrome")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, string Input) item)
        {
            var response = IsPalindrome(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(bool Output, string Input)> Input =>
            new List<(bool Output, string Input)>()
            {
                (false, "race a car"),
                (true, "A man, a plan, a canal: Panama"),
            };
    }
}
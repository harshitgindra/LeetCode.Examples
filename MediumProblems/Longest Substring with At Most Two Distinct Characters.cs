using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    public class Longest_Substring_with_At_Most_Two_Distinct_Characters
    {
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            int maxLength = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                var combo = new HashSet<char>() {s[i]};
                int j = i;
                for (; j < s.Length; j++)
                {
                    combo.Add(s[j]);

                    if (combo.Count > 2)
                    {
                        break;
                    }
                }

                if (combo.Count == 1)
                {
                    maxLength = s.Length;
                }
                maxLength = Math.Max(maxLength, j - i);
            }

            return maxLength;
        }

        [Test(Description = "https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Longest Substring with At Most Two Distinct Characters")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, string Input) item)
        {
            var response = LengthOfLongestSubstringTwoDistinct(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {
                    (1, "a"),
                    (5, "ccaabbb"),
                    (3, "eceba"),
                };
            }
        }
    }
}
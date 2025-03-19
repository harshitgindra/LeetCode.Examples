namespace LeetCode.HardProblems
{
    public class Longest_Substring_with_At_Most_K_Distinct_Characters
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (s == "")
                return 0;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            int left = 0, right = 0, maxlen = 0;

            while (right < s.Length)
            {
                char rightChar = s[right];
                if (dic.ContainsKey(rightChar))
                    dic[rightChar]++;
                else
                    dic.Add(rightChar, 1);
                right++;

                while (dic.Count > k)
                {
                    char leftChar = s[left];
                    dic[leftChar]--;
                    if (dic[leftChar] == 0)
                        dic.Remove(leftChar);
                    left++;
                }

                maxlen = Math.Max(maxlen, right - left);
            }

            return maxlen;
        }

        public int LengthOfLongestSubstringKDistinct2(string s, int k)
        {
            int maxLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var combo = new HashSet<char>() { s[i] };
                int j = i;
                for (; j < s.Length; j++)
                {
                    if (combo.Add(s[j]))
                    {
                        if (combo.Count > k)
                        {
                            break;
                        }
                    }
                }

                maxLength = Math.Max(maxLength, j - i);
            }

            return maxLength;
        }

        [Test(Description = "https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Longest Substring with At Most K Distinct Characters")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (string, int) Input) item)
        {
            var response = LengthOfLongestSubstringKDistinct(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, (string, int) Input)> Input =>
            new List<(int Output, (string, int) Input)>()
            {
                (3, ("eceba", 2)),
            };
    }
}
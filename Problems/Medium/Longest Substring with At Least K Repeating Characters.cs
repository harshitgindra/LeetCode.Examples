using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Medium
{
    class Longest_Substring_with_At_Least_K_Repeating_Characters
    {

        public int LongestSubstring(string s, int k)
        {
            int max = 0;
            int i = -1;
            var d = s.GroupBy(x => x)
                .ToDictionary(x => x.Key, y => y.Count());

            while (i + max < s.Length)
            {
                if (i >= 0)
                {
                    var c = s[i];
                    // d[c]--;
                    if (d[c]-- == 0)
                    {
                        d.Remove(c);
                    }
                }

                max = Reverse(i + 1, s, k, max, d);
                i++;
            }

            return max;
        }

        private int Reverse(int startIndex, string str, int k, int max, Dictionary<char, int> dp)
        {
            var dict = dp.ToDictionary(x => x.Key, y => y.Value);
            if (dict.Any() && dict.All(x => x.Value >= k))
            {
                max = Math.Max(max, str.Length);
            }
            else
            {
                for (int i = str.Length - 1; i >= startIndex; i--)
                {
                    if (max > dict.Values.Sum())
                    {
                        break;
                    }
                    else
                    {
                        var c = str[i];
                        dict[c]--;
                        if (dict[c] <= 0)
                        {
                            dict.Remove(c);
                        }
                        if (dict.Any() && dict.All(x => x.Value >= k))
                        {
                            max = Math.Max(max, i - startIndex);
                            break;
                        }
                    }
                }
            }

            return max;
        }

        [Test(Description = "https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Longest Substring with At Least K Repeating Characters")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (string, int) Input) item)
        {
            var response = LongestSubstring(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (string, int) Input)> Input
        {
            get
            {
                return new List<(int Output, (string, int) Input)>()
                {

                    //(1, ("a",1)),
                    //(3, ("ababbc",3)),
                    (0, ("aaabb",3)),
                    (0, ("dcbddccbacbcacb",3)),
                    (10, ("aaaaaaaaabbbcccccddddd",5)),
                    (3, ("ababacb",3)),
                };
            }
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Medium
{
    class Find_All_Anagrams_in_a_String
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> result = new List<int>();
            int pLength = p.Length;

            if (pLength < s.Length)
            {
                var a = p.OrderBy(x => x).ToArray();
                //Array.Sort(a);

                string str = "";
                bool prevAdded = false;
                char prevChar = default;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!p.Contains(s[i]))
                    {
                        str = "";
                        prevAdded = false;
                    }
                    else
                    {
                        str += s[i];
                        if (prevAdded && prevChar == s[i])
                        {
                            result.Add(i - pLength + 1);
                            prevChar = str[0];
                            str = str.Substring(1);
                        }
                        else if (str.Length == pLength)
                        {
                            if (IsAnagrams(a, str))
                            {
                                result.Add(i - pLength + 1);
                                prevAdded = true;
                            }
                            prevChar = str[0];
                            str = str.Substring(1);
                        }
                        else if (str.Length > p.Length)
                        {
                            str = str.Substring(1);
                        }
                        else
                        {
                            prevAdded = false;
                        }
                    }
                }
            }

            return result;
        }

        private bool IsAnagrams(char[] a, string str)
        {
            int index = 0;
            foreach (var item in str.OrderBy(x => x))
            {
                if (a[index] != item)
                {
                    return false;
                }
                index++;
            }
            return true;
        }

        public IList<int> FindAnagrams1(string s, string p)
        {
            var pOrdered = p.OrderBy(x => x);
            IList<int> result = new List<int>();

            if (p.Length < s.Length)
            {
                int index = 0;
                while (index < s.Length)
                {
                    string sb = "";
                    for (int i = index; i < index + p.Length; i++)
                    {
                        if (!p.Contains(s[i]))
                        {
                            index = i + 1;
                            break;
                        }
                        else
                        {
                            sb += s[i];
                        }
                    }

                    if (sb.Length == p.Length)
                    {
                        var subStr = sb.OrderBy(x => x);
                        if (IsAnagrams2(subStr, pOrdered, p.Length))
                        {
                            result.Add(index);
                        }
                        index++;
                    }
                }

            }

            return result;
        }

        private bool IsAnagrams2(IOrderedEnumerable<char> a, IOrderedEnumerable<char> b, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (a.ElementAt(i) != b.ElementAt(i))
                {
                    return false;
                }
            }
            return true;
        }

        public IList<int> FindAnagrams2(string s, string p)
        {
            var a = p.ToCharArray();
            Array.Sort(a);

            IList<int> result = new List<int>();

            List<char> b = new List<char>
            {
                '-'
            };
            for (int i = 0; i < p.Length - 1; i++)
            {
                b.Add(s[i]);
            }

            for (int i = p.Length - 1; i <= s.Length - 1; i++)
            {
                b.RemoveAt(0);
                b.Add(s[i]);

                //if (IsAnagrams(a, b))
                {
                    result.Add(i + 1 - p.Length);
                }
            }

            return result;
        }



        [Test(Description = "https://leetcode.com/problems/valid-anagram/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Valid Anagram")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (string, string) Input) item)
        {
            var response = FindAnagrams(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(int Output, (string, string) Input)>()
                {

                    (2, ("cbaebabacd", "abc")),
                    (3, ("abab", "ab")),
                    (4, ("abacbabc", "abc")),
                };
            }
        }
    }
}

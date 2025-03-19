

namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/find-all-anagrams-in-a-string/
    /// </summary>
    class Find_All_Anagrams_in_a_String
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> returnValue = new List<int>();

            if (!string.IsNullOrEmpty(s) && !string.IsNullOrEmpty(p)
                                         && s.Length >= p.Length)
            {
                var pDictionary = _ParseStringToMap(p);
                var sDictionary = _ParseStringToMap(s.Substring(0, p.Length));
                //***
                //*** Compare p and s dictionary
                //***
                if (_Compare(pDictionary, sDictionary))
                {
                    returnValue.Add(0);
                }

                int firstPointer = 0;

                for (int i = p.Length; i < s.Length; i++)
                {
                    char prevChar = s[firstPointer];
                    char nextChar = s[i];
                    //***
                    //*** Remove the char pointed by first pointer from the dictionary
                    //***
                    if (sDictionary[prevChar] == 1)
                    {
                        sDictionary.Remove(prevChar);
                    }
                    else
                    {
                        sDictionary[prevChar]--;
                    }
                    //***
                    //*** Add the new char to the dictionary
                    //***
                    if (sDictionary.ContainsKey(nextChar))
                    {
                        sDictionary[nextChar]++;
                    }
                    else
                    {
                        sDictionary.Add(nextChar, 1);
                    }
                    //***
                    //*** Compare p and s dictionary
                    //***
                    if (_Compare(pDictionary, sDictionary))
                    {
                        returnValue.Add(i-p.Length + 1);
                    }

                    firstPointer++;
                }
            }

            return returnValue;
        }

        private bool _Compare(IDictionary<char, int> dict1, IDictionary<char, int> dict2)
        {
            foreach (var item in dict1)
            {
                //***
                //*** Check if key exists and value/count should be equal
                //***
                if (!dict2.ContainsKey(item.Key) || dict2[item.Key] != item.Value)
                {
                    return false;
                }
            }

            return true;
        }

        private IDictionary<char, int> _ParseStringToMap(string str)
        {
            IDictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var c in str)
            {
                dict.TryAdd(c, 0);
                dict[c]++;
            }

            return dict;
        }


        public IList<int> FindAnagrams2(string s, string p)
        {
            IList<int> returnValue = new List<int>();

            if (!string.IsNullOrEmpty(s) && !string.IsNullOrEmpty(p)
                                         && s.Length >= p.Length)
            {
                p = string.Join("", p.OrderBy(x => x));
                int pLength = p.Length;
                for (int i = 0; i <= s.Length - p.Length; i++)
                {
                    string temp = s.Substring(i, pLength);
                    temp = string.Join("", temp.OrderBy(x => x));
                    if (p == temp)
                    {
                        returnValue.Add(i);
                    }
                }
            }

            return returnValue;
        }


        [Test(Description = "https://leetcode.com/problems/valid-anagram/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Valid Anagram")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (string, string) Input) item)
        {
            var response = FindAnagrams(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response.Count);
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
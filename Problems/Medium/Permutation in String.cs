using System.Collections;
using System.Collections.Generic;

namespace Leetcode.Problems.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/permutation-in-string/
    /// </summary>
    public class Permutation_in_String
    {
        public bool CheckInclusion(string s1, string s2)
        {
            bool returnValue = false;

            if (s1.Length <= s2.Length)
            {
                var d1 = _MapStringToDictionary(s1);
                var d2 = _MapStringToDictionary(s2.Substring(0, s1.Length));

                returnValue = _Compare(d1, d2);

                int prev = 0;
                for (int i = s1.Length; i < s2.Length; i++)
                {
                    if (!returnValue)
                    {
                        // remove prev char
                        if (d2[s2[prev]] == 1)
                        {
                            d2.Remove(s2[prev]);
                        }
                        else
                        {
                            d2[s2[prev]]--;
                        }

                        // add next char
                        d2.TryAdd(s2[i], 0);
                        d2[s2[i]]++;

                        returnValue = _Compare(d1, d2);
                    }
                    else
                    {
                        break;
                    }

                    prev++;
                }
            }

            return returnValue;
        }

        private bool _Compare(IDictionary<char, int> d1, IDictionary<char, int> d2)
        {
            bool returnValue = true;
            foreach (var item in d1)
            {
                returnValue &= d2.ContainsKey(item.Key) && d2[item.Key] == item.Value;
                if (!returnValue)
                {
                    break;
                }
            }

            return returnValue;
        }

        private IDictionary<char, int> _MapStringToDictionary(string str)
        {
            IDictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (var c in str)
            {
                dictionary.TryAdd(c, 0);
                dictionary[c]++;
            }

            return dictionary;
        }
    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    class Letter_Case_Permutation
    {
        public IList<string> LetterCasePermutation(string S)
        {
            IList<string> returnValue = new List<string>();
            if (!string.IsNullOrEmpty(S))
            {
                Permutation(returnValue, S, new StringBuilder(), S.Length, 0);
            }
            return returnValue;
        }

        private void Permutation(IList<string> returnValue, string S, StringBuilder str, int remaining, int current)
        {
            if (remaining == 0)
            {
                returnValue.Add(str.ToString());
            }
            else
            {
                if (char.IsLetter(S[current]))
                {
                    str.Append(char.ToUpper(S[current]));

                    Permutation(returnValue, S, str, remaining - 1, current + 1);

                    str.Remove(str.Length - 1, 1);

                    str.Append(char.ToLower(S[current]));

                    Permutation(returnValue, S, str, remaining - 1, current + 1);

                    str.Remove(str.Length - 1, 1);
                }
                else
                {
                    str.Append(S[current]);

                    Permutation(returnValue, S, str, remaining - 1, current + 1);

                    str.Remove(str.Length - 1, 1);
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/letter-case-permutation/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Letter Case Permutation")]
        [TestCaseSource("Input")]
        public void Test1((int Output, string Input) item)
        {
            var response = LetterCasePermutation(item.Input);
            ClassicAssert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {

                    (4, "a1b2"),
                };
            }
        }
    }
}

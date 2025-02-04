using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    class ReverseOnlyLettersTest
    {
        public string ReverseOnlyLetters(string S)
        {
            if (string.IsNullOrEmpty(S))
            {
                return string.Empty;
            }
            else
            {
                var arry = S.ToCharArray();
                int sIndex = 0;
                int eIndex = S.Length - 1;
                while (sIndex < eIndex)
                {
                    if (char.IsLetter(arry[sIndex]))
                    {
                        if (char.IsLetter(arry[eIndex]))
                        {
                            var temp = arry[eIndex];
                            arry[eIndex--] = arry[sIndex];
                            arry[sIndex++] = temp;
                        }
                        else
                        {
                            eIndex--;
                        }
                    }
                    else
                    {
                        sIndex++;
                    }
                }

                return string.Join("", arry);
            }
        }

        [Test(Description = "https://leetcode.com/problems/reverse-only-letters/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Reverse Only Letters")]
        [TestCaseSource("Input")]
        public void Test1((string Output, string Input) item)
        {
            var response = ReverseOnlyLetters(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, string Input)> Input
        {
            get
            {
                return new List<(string Output, string Input)>()
                {
                    ("Qedo1ct-eeLg=ntse-T!", "Test1ng-Leet=code-Q!"),
                };
            }
        }
    }
}

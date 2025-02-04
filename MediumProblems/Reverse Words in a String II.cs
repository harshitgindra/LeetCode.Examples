using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    class Reverse_Words_in_a_String_II
    {
        public void ReverseWords(char[] s)
        {
            var tempArry = s.ToArray();
            int sIndex = 0;
            int eIndex = tempArry.Length;
            for (int i = tempArry.Length - 1; i >= -1; i--)
            {
                if (i == -1)
                {
                    for (int j = i + 1; j < eIndex; j++)
                    {
                        s[sIndex] = tempArry[j];
                        sIndex++;
                    }
                }
                else if (tempArry[i] == ' ')
                {
                    for (int j = i + 1; j < eIndex; j++)
                    {
                        s[sIndex] = tempArry[j];
                        sIndex++;
                    }
                    s[sIndex] = ' ';
                    sIndex++;
                    eIndex = i;
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/reverse-words-in-a-string-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Reverse Words in a String II")]
        [TestCaseSource("Input")]
        public void Test1((char[] Output, char[] Input) item)
        {
            ReverseWords(item.Input);
            ClassicAssert.AreEqual(item.Output, item.Input);
        }

        public static IEnumerable<(char[] Output, char[] Input)> Input
        {
            get
            {
                return new List<(char[] Output, char[] Input)>()
                {
                    (new char[]{ 'b','l','u','e',' ','i','s',' ','s','k','y',' ','t','h','e'},
                    new char[]{'t','h','e',' ','s','k','y',' ','i','s',' ','b','l','u','e' })
                };
            }
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    class Replace_All_to_Avoid_Consecutive_Repeating_Characters
    {
        public string ModifyString(string s)
        {
            var dict = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict[i] == '?')
                {
                    char prevItem = 'a';
                    char nextItem = 'a';
                    if (i > 0)
                    {
                        prevItem = dict[i - 1];
                    }
                    if (i < s.Length - 1)
                    {
                        nextItem = dict[i + 1];
                    }

                    var nextChar = IncrementCharacter(prevItem);
                    if (nextChar == nextItem)
                    {
                        nextChar = IncrementCharacter(nextChar);
                    }

                    dict[i] = nextChar;
                }
            }

            return string.Join("", dict);
        }
        char IncrementCharacter(char input)
        {
            return (input == 'z' ? 'a' : (char)(input + 1));
        }

        [Test(Description = "https://leetcode.com/problems/replace-all-s-to-avoid-consecutive-repeating-characters/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Replace All ?'s to Avoid Consecutive Repeating Characters")]
        [TestCaseSource("Input")]
        public void Test1((string Output, string Input) item)
        {
            var response = ModifyString(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, string Input)> Input
        {
            get
            {
                return new List<(string Output, string Input)>()
                {
                    ("azs", "ubv?w"),
                    ("azs", "??yw?ipkj?"),
                    ("azs", "?zs"),
                };
            }
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    class Verifying_an_Alien_Dictionary
    {
        public bool IsAlienSorted(string[] words, string order)
        {
            int index = 0;
            var dict = order.ToDictionary(x => index++, y => y);

            int[] val = new int[words.Length];

            words = words.OrderBy(x => x.Length).ToArray();

            for (int i = 0; i < words.Length; i++)
            {

            }

            return false;;
        }

        [Test(Description = "https://leetcode.com/problems/verifying-an-alien-dictionary/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Verifying an Alien Dictionary")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (string[], string) Input) item)
        {
            var response = IsAlienSorted(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (string[], string) Input)> Input
        {
            get
            {
                return new List<(bool Output, (string[], string) Input)>()
                {
                    (true, (new string[]{ "hello","leetcode"}, "hlabcdefgijkmnopqrstuvwxyz"))
                };
            }
        }
    }
}

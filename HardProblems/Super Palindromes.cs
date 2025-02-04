using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Hard
{
    class Super_Palindromes
    {
        public int SuperpalindromesInRange(string L, string R)
        {
            var lInt = Convert.ToInt32(L);
            var RInt = Convert.ToInt32(R);

            for (int i = lInt; i <= RInt; i++)
            {
                var response = IsPerfectSquare(i);
                if (response.Item1 && IsPalindromeNumber($"{response.Item2}")
                    && IsPalindromeNumber($"{i}"))
                {
                    return i;
                }
            }
            return 0;
        }

        private (bool, double) IsPerfectSquare(int num)
        {
            double result = Math.Sqrt(num);
            return (result % 1 == 0, result);
        }

        bool IsPalindromeNumber(string str)
        {
            if (str.Length == 1 || str.Length == 0) return true;
            return str[0] == str[str.Length - 1] && IsPalindromeNumber(str.Substring(1, str.Length - 2));
        }

        [Test(Description = "https://leetcode.com/problems/super-palindromes/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Super Palindromes")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (string, string) Input) item)
        {
            var response = SuperpalindromesInRange(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(int Output, (string, string) Input)>()
                {
                    (4, ("4", "1000")),
                };
            }
        }
    }
}

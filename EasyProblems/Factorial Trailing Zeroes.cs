using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Factorial_Trailing_Zeroes
    {
        public int TrailingZeroes(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {
                int product = 1;
                for (int i = 2; i <= n; i++)
                {
                    product *= i;
                }

                var str = product.ToString();
                int ret = 0;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (str[i] == '0')
                    {
                        ret++;
                    }
                }
                return ret;
            }
        }

        [Test(Description = "https://leetcode.com/problems/isomorphic-strings/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Isomorphic Strings")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int Input) item)
        {
            var response = TrailingZeroes(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int Input)> Input
        {
            get
            {
                return new List<(int Output, int Input)>()
                {

                    (2, 7),
                    (2, 13),
                    (1, 5),
                };
            }
        }
    }
}

using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Decode_Ways
    {
        public int NumDecodings(string s)
        {
            //***
            //*** Validate if string is null/empty
            //*** or starts with 0
            //***
            if (string.IsNullOrEmpty(s) || s[0] == '0')
            {
                return 0;
            }
            //***
            //*** Initialize dp array
            //***
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= s.Length; i++)
            {
                //***
                //*** Get the current number and the previous number
                //***
                int num1 = int.Parse(s.Substring(i - 1, 1));
                int num2 = int.Parse(s.Substring(i - 2, 2));

                //***
                //*** If current number is greater than 0, its a valid number
                //*** We take the combination calculated of the previous index
                //***
                int c1 = num1 > 0 ? dp[i - 1] : 0;
                //***
                //*** If combination of current and previous number is valid, 
                //*** We take the combinations calculated 2 places from current index
                //***
                int c2 = num2 >= 10 && num2 <= 26 ? dp[i - 2] : 0;
                dp[i] = c1 + c2;
            }

            return dp[s.Length];
        }

        [Test(Description = "https://leetcode.com/problems/decode-ways/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Decode Ways")]
        [TestCaseSource("Input")]
        public void Test1((int Output, string Input) item)
        {
            var response = NumDecodings(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {

                    (3, "226"),
                    (0,"0")
                };
            }
        }
    }
}

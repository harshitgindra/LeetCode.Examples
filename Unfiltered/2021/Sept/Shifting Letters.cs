using NUnit.Framework.Legacy;

namespace LeetCode.Problems._2021.Sept
{
    class Shifting_Letters
    {
        readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public string ShiftingLetters(string s, int[] shifts)
        {
            long totalShifts = 0;
            char[] returnValue = new char[s.Length];
            for (int i = shifts.Length - 1; i >= 0; i--)
            {
                //***
                //*** Accumulate all shifts from the shift variable
                //***
                totalShifts += shifts[i];
                //*** 
                //*** Get the index of current char from alphabet and add total shifts
                //***
                var newCharIndex = (int)((alphabet.IndexOf(s[i]) + totalShifts) % 26);
                returnValue[i] = alphabet[newCharIndex];
            }

            return new string(returnValue);
        }

        [Test(Description = "https://leetcode.com/problems/shifting-letters/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Shifting Letters")]
        [TestCaseSource("Input")]
        public void Test1((string Output, (string s, int[] shifts) Input) item)
        {
            var response = ShiftingLetters(item.Input.s, item.Input.shifts);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, (string s, int[] shifts) Input)> Input
        {
            get
            {
                return new List<(string Output, (string s, int[] shifts) Input)>()
                {
                    ("gfd",("aaa", new int[]{ 1,2,3})),
                    ("rpl",("abc", new int[]{ 3,5,9})),
                };
            }
        }
    }
}

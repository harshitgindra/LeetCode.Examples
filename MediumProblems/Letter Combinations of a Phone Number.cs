

namespace LeetCode.MediumProblems
{
    class LetterCombinationsofaPhoneNumber
    {
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> results = new List<string>();

            if (!string.IsNullOrEmpty(digits))
            {
                Build(digits.Length, "", digits, results);
            }

            return results;
        }

        private void Build(int maxLength, string code, string input, IList<string> results)
        {
            if (code.Length == maxLength)
            {
                results.Add(code);
            }
            else
            {
                var numCode = keyCodes[input[code.Length]];
                for (int i = 0; i < numCode.Length; i++)
                {
                    code += numCode[i];
                    Build(maxLength, code, input, results);
                    code = code.Remove(code.Length - 1);
                }
            }
        }

        IDictionary<char, string> keyCodes = new Dictionary<char, string>
            {
                {'2', "abc" },
                {'3', "def" },
                {'4', "ghi" },
                {'5', "jkl" },
                {'6', "mno" },
                {'7', "pqrs" },
                {'8', "tuv" },
                {'9', "wxyz" },
            };



        [Test(Description = "https://leetcode.com/problems/letter-combinations-of-a-phone-number/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Letter Combinations of a Phone Number")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, string Input) item)
        {
            var response = LetterCombinations(item.Input);
            ClassicAssert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {
                    (9, "23"),
                    (9, "22"),
                    (27, "234"),
                };
            }
        }
    }
}

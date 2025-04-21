namespace LeetCode.MediumProblems
{
    class LetterCombinationsofaPhoneNumber
    {
        // Time: O(4^n)
        // Space: O(4^n)
        
        // Dictionary mapping each digit to its possible characters on a phone keypad
        private readonly Dictionary<char, IReadOnlyList<char>> _digitToLettersMap =
            new()
            {
                { '2', ['a', 'b', 'c'] },
                { '3', ['d', 'e', 'f'] },
                { '4', ['g', 'h', 'i'] },
                { '5', ['j', 'k', 'l'] },
                { '6', ['m', 'n', 'o'] },
                { '7', ['p', 'q', 'r', 's'] },
                { '8', ['t', 'u', 'v'] },
                { '9', ['w', 'x', 'y', 'z'] }
            };

        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();

            // Handle edge case: return empty list if input is empty
            if (string.IsNullOrEmpty(digits))
            {
                return result;
            }

            // Start the recursive DFS process with initial empty combination
            GenerateCombinations(digits, 0, string.Empty, result);

            return result;
        }

        private void GenerateCombinations(
            string digits,
            int currentIndex,
            string currentCombination,
            List<string> results)
        {
            // Base case: if we've processed all digits, add the complete combination
            if (currentIndex == digits.Length)
            {
                results.Add(currentCombination);
                return;
            }

            // Get the current digit and its corresponding letters
            char currentDigit = digits[currentIndex];

            // For each letter corresponding to the current digit
            foreach (char letter in _digitToLettersMap[currentDigit])
            {
                // Add the current letter to our combination and recurse to the next digit
                GenerateCombinations(
                    digits,
                    currentIndex + 1,
                    currentCombination + letter,
                    results);
            }
        }

        [Test(Description = "https://leetcode.com/problems/letter-combinations-of-a-phone-number/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Letter Combinations of a Phone Number")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, string Input) item)
        {
            var response = LetterCombinations(item.Input);
            Assert.That(response.Count, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, string Input)> Input =>
            new List<(int Output, string Input)>()
            {
                (9, "23"),
                (9, "22"),
                (27, "234"),
            };
    }
}
using System.Text;

namespace LeetCode.MediumProblems
{
    class GenerateParentheses
    {
        public IList<string> GenerateParenthesis(int n) {
            List<string> result = new List<string>();
            StringBuilder current = new StringBuilder();
            Backtrack(result, current, 0, 0, n);
            return result;
        }

        private void Backtrack(
            List<string> result, 
            StringBuilder current, 
            int open, 
            int close, 
            int max
        ) {
            // Base case: valid combination complete
            if (current.Length == max * 2) {
                result.Add(current.ToString());
                return;
            }

            // Add open parenthesis if we haven't reached the limit
            if (open < max) {
                current.Append('(');
                Backtrack(result, current, open + 1, close, max);
                current.Remove(current.Length - 1, 1); // Backtrack
            }

            // Add close parenthesis if it won't create imbalance
            if (close < open) {
                current.Append(')');
                Backtrack(result, current, open, close + 1, max);
                current.Remove(current.Length - 1, 1); // Backtrack
            }
        }

        [Test(Description = "https://leetcode.com/problems/generate-parentheses/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Generate Parentheses")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int Input) item)
        {
            var response = GenerateParenthesis(item.Input);
            Assert.That(response.Count, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int Input)> Input =>
            new List<(int Output, int Input)>()
            {
                (5, 3),
            };
    }
}

namespace LeetCode.EasyProblems
{
    public class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            // Negative numbers and non-zero numbers ending with 0 can't be palindromes
            if (x < 0 || (x % 10 == 0 && x != 0))
                return false;

            int reversedHalf = 0;
            // Extract and reverse the last half of the number
            while (x > reversedHalf)
            {
                reversedHalf = reversedHalf * 10 + x % 10;
                x /= 10;
            }

            // For even digits: x == reversedHalf
            // For odd digits: x == reversedHalf/10 (middle digit is ignored)
            return x == reversedHalf || x == reversedHalf / 10;
        }
        
        [Test(Description = "https://leetcode.com/problems/palindrome-number/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Palindrome Number")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, int Input) item)
        {
            var response = IsPalindrome(item.Input);
            Assert.That(item.Output, Is.EqualTo(response));
        }

        public static IEnumerable<(bool Output, int Input)> Input =>
            new List<(bool Output, int Input)>()
            {
                (true, 121),
            };
    }
}
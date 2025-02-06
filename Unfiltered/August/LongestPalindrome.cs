namespace LeetCode.August
{
    public class LongestPalindromeTest
    {
        public int LongestPalindrome(string s)
        {
            int maxLength = s.Length;

            if (maxLength == 1)
            {
                return 1;
            }

            s = string.Concat(s.OrderBy(c => c));

            int startIndex = 0;
            int returnValue = 0;

            while (startIndex < maxLength)
            {
                int nextIndex = startIndex + 1;
                if (nextIndex != maxLength && s[startIndex] == s[nextIndex])
                {
                    startIndex += 2;
                    returnValue += 2;
                }
                else
                {
                    startIndex++;
                    if (returnValue % 2 != 0) continue;
                    returnValue++;
                }
            }

            return returnValue;
        }
    }
}

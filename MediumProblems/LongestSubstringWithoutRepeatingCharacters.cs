namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// </summary>
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> uniqueChars = new HashSet<char>(); // Track unique characters in current window
            int windowStart = 0; // Left boundary of window
            int maxLength = 0; // Result: length of longest substring

            // Slide windowEnd across the string
            foreach (int windowEnd in Enumerable.Range(0, s.Length))
            {
                // If current character is already in set, move windowStart right
                while (uniqueChars.Contains(s[windowEnd]))
                {
                    uniqueChars.Remove(s[windowStart]);
                    windowStart++;
                }

                // Add current character to set
                uniqueChars.Add(s[windowEnd]);
                // Update maxLength if current window is larger
                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
            }

            return maxLength;
        }
    }
}
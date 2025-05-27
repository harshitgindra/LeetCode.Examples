namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-words-in-a-string/
    /// </summary>
    public class ReverseWordsInAString
    {
        public string ReverseWords(string s)
        {
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries
                                          | StringSplitOptions.TrimEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }
    }
}
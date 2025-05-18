namespace LeetCode.EasyProblems;

/// <summary>
/// https://leetcode.com/problems/longest-unequal-adjacent-groups-subsequence-i/
/// </summary>
public class LongestUnequalAdjacentGroupsSubsequenceI
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        // Result list to store the longest subsequence
        List<string> ans = new List<string>();

        // Iterate through the words and groups arrays
        for (int i = 0; i < groups.Length; ++i)
        {
            // Add the first word, or add the word if the group changes from the previous one
            if (i == 0 || groups[i] != groups[i - 1])
            {
                ans.Add(words[i]);
            }
        }

        // Return the resulting subsequence
        return ans;
    }
}
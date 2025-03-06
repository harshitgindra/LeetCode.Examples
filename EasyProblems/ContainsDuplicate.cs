namespace LeetCode.EasyProblems;

/// <summary>
/// Leetcode 217
/// https://leetcode.com/problems/contains-duplicate/
/// </summary>
public class ContainsDuplicateSolution
{
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> duplicates = new HashSet<int>();
        foreach (var item in nums)
        {
            if (!duplicates.Add(item))
            {
                return true;
            }
        }

        return false;
    }
}
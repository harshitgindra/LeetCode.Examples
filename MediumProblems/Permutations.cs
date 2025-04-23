namespace LeetCode.MediumProblems;

/// <summary>
/// https://leetcode.com/problems/permutations/
/// </summary>
public class Permutations
{
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        GeneratePermutations(nums, new List<int>(), result);
        return result;
    }

   
    private void GeneratePermutations(int[] nums, List<int> currentPermutation, IList<IList<int>> result) {
        // Base case: if current permutation has all elements, add it to result
        if (currentPermutation.Count == nums.Length) {
            // Create a new list to avoid reference issues
            result.Add(new List<int>(currentPermutation));
            return;
        }
        
        // Try adding each number from nums to the current permutation
        foreach (int num in nums) {
            // Skip if the number is already in the current permutation
            if (currentPermutation.Contains(num)) 
                continue;
                
            // Add the number to the current permutation
            currentPermutation.Add(num);
            
            // Recursively generate permutations with the updated current permutation
            GeneratePermutations(nums, currentPermutation, result);
            
            // Backtrack: remove the last added number to try different combinations
            currentPermutation.RemoveAt(currentPermutation.Count - 1);
        }
    }
}
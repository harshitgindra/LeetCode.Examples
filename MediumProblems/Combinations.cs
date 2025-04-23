namespace LeetCode.MediumProblems;
/// <summary>
/// https://leetcode.com/problems/combinations/
/// </summary>
public class Combinations
{
    public IList<IList<int>> Combine(int n, int k) {
        var result = new List<IList<int>>();
        Backtrack(1, n, k, new List<int>(), result);
        return result;
    }
    
    private void Backtrack(int start, int n, int k, List<int> current, List<IList<int>> result) {
        // Base case: if we've selected k numbers, add the combination to our result
        if (current.Count == k) {
            result.Add(new List<int>(current)); // Create a new list to avoid reference issues
            return;
        }
        
        // Optimization: only consider numbers that can lead to valid combinations
        // We need (k - current.Count) more numbers, so we can only go up to n - (k - current.Count) + 1
        for (int i = start; i <= n - (k - current.Count) + 1; i++) {
            current.Add(i);
            Backtrack(i + 1, n, k, current, result);
            current.RemoveAt(current.Count - 1); // Backtrack
        }
    }
}
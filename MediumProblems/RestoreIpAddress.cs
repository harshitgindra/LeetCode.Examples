namespace LeetCode.MediumProblems;

/// <summary>
/// https://leetcode.com/problems/restore-ip-addresses/
/// </summary>
public class RestoreIpAddress
{
    public IList<string> RestoreIpAddresses(string s) {
        List<string> result = new List<string>();
        if (s.Length < 4 || s.Length > 12) return result;
        Backtrack(s, 0, new List<string>(), result);
        return result;
    }
    
    private void Backtrack(string s, int start, List<string> currentSegments, List<string> result) {
        if (currentSegments.Count == 4 && start == s.Length) {
            result.Add(string.Join(".", currentSegments));
            return;
        }
        if (currentSegments.Count == 4 || start >= s.Length) return;
        
        for (int len = 1; len <= 3; len++) {
            if (start + len > s.Length) break;
            string segment = s.Substring(start, len);
            if (segment[0] == '0' && segment.Length > 1) continue;
            if (int.Parse(segment) > 255) continue;
            currentSegments.Add(segment);
            Backtrack(s, start + len, currentSegments, result);
            currentSegments.RemoveAt(currentSegments.Count - 1);
        }
    }
}
namespace Easy;

/// <summary>
/// https://leetcode.com/problems/word-pattern/
/// 290
/// </summary>
public class Word_Pattern
{
    public bool WordPattern(string pattern, string s) {
        var arry = s.Split(" ");

        if (pattern.Length != arry.Length)
        {
            return false;
        }

        var dict = new Dictionary<char, string>();

        for (int i = 0; i < pattern.Length; i++)
        {
            if (dict.ContainsKey(pattern[i]))
            {
                if (dict[pattern[i]] != arry[i])
                {
                    return false;
                }
            }
            else if (dict.Values.Contains(arry[i]))
            {
                return false;
            }
            else
            {
                dict.Add(pattern[i], arry[i]);
            }
        }

        return true;
    }
}
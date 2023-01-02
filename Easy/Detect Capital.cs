namespace Easy;

/// <summary>
/// https://leetcode.com/problems/detect-capital/
/// 520
/// </summary>
public class Detect_Capital
{
    public bool DetectCapitalUse(string word)
    {
        if (word.Length > 1)
        {
            if (char.IsUpper(word[0]) && char.IsUpper(word[1]))
            {
                // first and second character are upper, rest all characters should be upper
                for (int i = 2; i < word.Length; i++)
                {
                    if (char.IsLower(word[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // first char is lower, all characters should be lower
                for (int i = 1; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
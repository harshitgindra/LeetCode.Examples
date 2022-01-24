namespace Leetcode.Problems._2022.January
{
    /// <summary>
    /// https://leetcode.com/problems/detect-capital/
    /// </summary>
    public class Detect_Capital
    {
        public bool DetectCapitalUse(string word) {
        
            if(word == "")
                return false;
        
            return word == word.ToUpper() || word.Substring(1) == word.Substring(1).ToLower();
        }
    }
}
namespace LeetCode.MediumProblems
{
    public class LongestSubstringWithoutRepeatingCharacters
    {


        public int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;

            for (var i = 0; i < s.Length; i++)
            {
                for (var j = maxLength; j <= s.Length - i; j++)
                {
                    if (maxLength < j)
                    {
                        string subStr = s.Substring(i, j);
                        if (subStr.Length == subStr.Distinct().Count())
                        {
                            maxLength = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return maxLength;
        }

      
    }
}

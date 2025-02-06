namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/determine-if-string-halves-are-alike/
    /// </summary>
    public class Determine_if_String_Halves_Are_Alike
    {
        public bool HalvesAreAlike(string s)
        {
            int sIndex = 0;
            int eIndex = s.Length - 1;
            HashSet<char> vowels = new HashSet<char>()
            {
                'a', 'e', 'i', 'o', 'u',
                'A', 'E', 'I', 'O', 'U',
            };

            int count = 0;
            
            while (sIndex < eIndex)
            {
                if (vowels.Contains(s[sIndex]))
                {
                    count++;
                }
                
                if (vowels.Contains(s[eIndex]))
                {
                    count--;
                }

                sIndex++;
                eIndex--;
            }

            return count == 0;
        }
    }
}
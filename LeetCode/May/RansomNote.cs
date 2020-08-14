using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.May
{
    public class RansomNote
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            foreach (var chars in ransomNote)
            {
                if (!magazine.Contains(chars))
                {
                    return false;
                }
                else
                {
                    magazine = magazine.Remove(magazine.IndexOf(chars), 1);
                }
            }

            return true;
        }
    }
}

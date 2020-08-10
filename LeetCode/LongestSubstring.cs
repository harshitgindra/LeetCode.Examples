using System;

namespace LeetCode
{
    public class LongestSubstring
    {
        public LongestSubstring()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Longest Substring");
            Console.WriteLine("----------------------------------------------------------");
        }
        
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || IsPalindrome(s))
            {
                return s;
            }
            else
            {
                string returnValue = "";

                int sLength = s.Length;
                for (int i = 0; i < sLength-1; i++)
                {
                    int palindromeTextLength = returnValue.Length;
                    for (int j = sLength - i; j > palindromeTextLength; j--)
                    {
                        //*** check if i+j is less than word length
                        //if (sLength >= i + j)
                        {
                            string subStr = s.Substring(i, j);

                            if (IsPalindrome(subStr))
                            {
                                returnValue = subStr;
                                break;
                            }
                        }
                        //else if (j + palindromeTextLength >= sLength)
                        //{
                        //    break;
                        //}
                    }
                }
                return returnValue;
            }
        }

        
        bool IsPalindrome(string str)
        {
            if(str.Length == 1 || str.Length == 0) return true;
            return str[0] == str[^1] && IsPalindrome(str.Substring(1,str.Length-2));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class ValidPalindrome
    {
        public ValidPalindrome()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Valid Palindrome");
            Console.WriteLine("----------------------------------------------------------");
        }

        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            else
            {
                return IsPalindromeString(s.ToLower());
            }
        }

        bool IsPalindromeString(string str)
        {
            int sLength = str.Length;
            if (sLength < 2)
            {
                return true;
            }

            char a = str[0];
            char c = ""[0];


            if (char.IsLetterOrDigit(a))
            {
                char b = str[sLength - 1];
                if (char.IsLetterOrDigit(b))
                {
                    //***
                    //*** Both ends are valid alphanumeric 
                    //***
                    return char.ToLower(a) == char.ToLower(b)
                           && IsPalindromeString(str.Substring(1, sLength - 2));
                }
                else
                {
                    str = str.Replace($"{b}", string.Empty);
                    return IsPalindrome(str);
                }
            }
            else
            {
                str = str.Replace($"{a}", string.Empty);
                return IsPalindrome(str);
            }
        }
    }
}

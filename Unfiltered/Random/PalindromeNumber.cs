namespace LeetCode
{
    public class PalindromeNumber
    {
        public PalindromeNumber()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Palindrome Number");
            Console.WriteLine("----------------------------------------------------------");
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                //*** number is negative, can't be a palindrome number
                return false;
            }

            return IsPalindromeNumber($"{x}");
        }

        public bool IsPalindromeNumber2(string s)
        {
            if (s.Length == 1)
            {
                return true;
            }

            char[] ch = s.ToCharArray();
            if (ch[0] == ch[^1])
            {
                Array.Reverse(ch);
                return s == new string(ch);
            }

            return false;
        }

        bool IsPalindromeNumber(string str)
        {
            if (str.Length == 1 || str.Length == 0) return true;
            return str[0] == str[str.Length - 1] && IsPalindromeNumber(str.Substring(1, str.Length - 2));
        }
    }
}
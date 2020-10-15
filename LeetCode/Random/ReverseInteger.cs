using System;

namespace LeetCode
{
    public class ReverseInteger
    {
        public ReverseInteger()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Reverse Integer");
            Console.WriteLine("----------------------------------------------------------");
        }
        
        public int Reverse(int x)
        {
            try
            {
                if (x < 0)
                {
                    return Convert.ToInt32(Reverse($"{Math.Abs(x)}")) * -1;
                }
                else
                {
                    return Convert.ToInt32(Reverse($"{x}"));
                }
            }
            catch (OverflowException)
            {
                return 0;
            }
        }

        public string Reverse(string s)
        {
            char[] ch = s.ToCharArray();
            Array.Reverse(ch);
            return new string(ch);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class NumberOf1Bits
    {
        public NumberOf1Bits()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Number Of 1 Bits");
            Console.WriteLine("----------------------------------------------------------");
        }

        public int HammingWeight(uint n)
        {
            //***
            //*** Convert int to binary
            //***
            string str = Convert.ToString(n, 2);
            return str.Count(x => x == '1');
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.May
{
    public class NumberComplement
    {
        public int FindComplement(int num)
        {
            string binary = Convert.ToString(num, 2);
            binary = binary.Replace("0", "*")
                .Replace("1", "0")
                .Replace("*", "1");
            return Convert.ToInt32(binary, 2);
        }
    }
}

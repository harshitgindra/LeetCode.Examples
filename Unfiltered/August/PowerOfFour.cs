using System;

namespace LeetCode
{
    public class PowerOfFour
    {
        public PowerOfFour()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Power Of Four");
            Console.WriteLine("----------------------------------------------------------");
        }

        public bool IsPowerOfFour(int num)
        {
            //***
            //*** If num is 0 or less than 0, return false
            //***
            if (num == 0 || num < 0)
            {
                return false;
            }
            //***
            //*** Get the division of the log of num and 4
            //*** Return true if the number is not a whole number
            //***
            var mathValue = Math.Log(num) / Math.Log(4);
            return  (int)mathValue == mathValue;
        }
    }
}

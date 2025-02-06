namespace LeetCode
{
    public class PowerOfTwo
    {
        public PowerOfTwo()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Power Of Two");
            Console.WriteLine("----------------------------------------------------------");
        }

        public bool IsPowerOfTwo(int n)
        {
            //***
            //*** Get the division of the log of num and 2
            //*** Return true if the number is not a whole number
            //***
            return n > 0 && ((n & (n - 1)) == 0);
        }

        public bool IsPowerOfThree(int num)
        {
            //***
            //*** If num is 0 or less than 0, return false
            //***
            if (num == 0 || num < 0)
            {
                return false;
            }
            //***
            //*** Maximum integer which is the power of 3
            //***
            return 1162261467 % num == 0;
        }
    }
}

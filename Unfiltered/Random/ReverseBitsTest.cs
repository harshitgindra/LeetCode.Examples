namespace LeetCode
{
    public class ReverseBitsTest
    {
        public ReverseBitsTest()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Reverse Bits Test");
            Console.WriteLine("----------------------------------------------------------");
        }

        public uint reverseBits(uint n)
        {
            //***
            //*** Convert int to binary, and convert to char array
            //***
            char[] arr = Convert.ToString(n, 2).ToCharArray();
            //***
            //*** Reverse the array contents
            //***
            Array.Reverse(arr);
            //***
            //*** padd ending zeros to make it 32 bit Convert array to string and then to unint
            //***
            return Convert.ToUInt32(new string(arr).PadRight(32, '0'), 2);
        }
    }
}

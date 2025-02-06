namespace LeetCode
{
    public class SingleNumberIITest
    {
        public SingleNumberIITest()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Single Number II Test");
            Console.WriteLine("----------------------------------------------------------");
        }



        public int SingleNumber(int[] nums)
        {
            IDictionary<int, int> i = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (i.ContainsKey(num))
                {
                    if (i[num] == 2)
                    {
                        i.Remove(num);
                    }
                    else
                    {
                        i[num] = 2;
                    }
                }
                else
                {
                    i.Add(num, 1);
                }
            }

            return i.First().Key;
        }
    }
}

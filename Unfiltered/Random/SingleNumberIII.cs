namespace LeetCode
{
    public class SingleNumberIII
    {
        public SingleNumberIII()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Single Number Test");
            Console.WriteLine("----------------------------------------------------------");
        }

        public int[] SingleNumber(int[] nums)
        {
            HashSet<int> i = new HashSet<int>();
            foreach (var num in nums)
            {
                if (i.Contains(num))
                {
                    i.Remove(num);
                }
                else
                {
                    i.Add(num);
                }
            }

            return new int[] { i.First(), i.Skip(1).First() };
        }
    }
}

namespace LeetCode.Hard
{
    class Non_negative_Integers_without_Consecutive_Ones
    {
        public int FindIntegers(int num)
        {
            int returnValue = num;
            for (int i = 0; i <= num; i++)
            {
                string binary = Convert.ToString(i, 2);
                if (binary.Contains("11"))
                {
                    returnValue--;
                }
            }

            return Enumerable.Range(0,num).Count(x=>!Convert.ToString(x, 2).Contains("11"));

            return returnValue;
        }
    }
}

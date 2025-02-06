﻿namespace LeetCode.May
{
    public class JewelsAndStonesTest
    {
        public int NumJewelsInStones(string J, string S)
        {
            int sum = 0;
          
            foreach (var item in J)
            {
                sum += S.Count(x => x == item);
            }

            return sum;
        }
    }
}

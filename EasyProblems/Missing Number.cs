namespace LeetCode.EasyProblems
{
    public class Missing_Number
    {
        /// <summary>
        /// https://leetcode.com/problems/missing-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            var hSet = nums.ToHashSet();
            for(int i = 0; i< Int32.MaxValue; i++)
            {
                if (!hSet.Contains(i))
                {
                    return i;
                }
                else
                {
                    hSet.Remove(i);
                }
            }
            return Int32.MaxValue;
        }
    }
}

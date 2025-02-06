namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/find-pivot-index/
    /// </summary>
    class PivotIndexTest
    {
        public int PivotIndex(int[] nums)
        {
            int rhs = nums.Sum();

            int lhs = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                rhs = rhs - nums[i];
                if (lhs == rhs)
                {
                    return i;
                }
                else
                {
                    lhs += nums[i];
                }
            }

            return -1;
        }
    }
}

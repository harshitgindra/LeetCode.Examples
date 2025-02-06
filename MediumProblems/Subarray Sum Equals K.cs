namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/subarray-sum-equals-k/
    /// </summary>
    public class Subarray_Sum_Equals_K
    {
        public int SubarraySum(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            dict.Add(0, 1);
            
            int ret = 0, sum = 0;
            foreach (var n in nums)
            {
                sum += n;
                if (dict.ContainsKey(sum - k))
                {
                    ret += dict[sum - k];
                }

                if (!dict.ContainsKey(sum))
                {
                    dict.Add(sum, 0);

                }
                
                dict[sum]++;
            }

            return ret;
        }
    }
}
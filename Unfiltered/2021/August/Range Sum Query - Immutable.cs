namespace LeetCode.Problems._2021.August
{
    /// <summary>
    /// https://leetcode.com/problems/range-sum-query-immutable/solution/
    /// </summary>
    class NumArray
    {
        private readonly IDictionary<int, int> _nums;

        public NumArray(int[] nums)
        {
            _nums = new Dictionary<int, int>();
            int i = 0;
            foreach (var item in nums)
            {
                _nums.Add(i++, item);
            }
        }

        public int SumRange(int left, int right)
        {
            int total = 0;
            for(int i = left; i<=right; i++)
            {
                if (_nums.ContainsKey(i))
                {
                    total+= _nums[i];
                }
            }

            return total;
        }
    }
}

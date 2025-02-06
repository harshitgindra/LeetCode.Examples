namespace LeetCode.Mock
{
    /// <summary>
    /// https://leetcode.com/problems/product-of-array-except-self/
    /// </summary>
    class ProductExceptSelfTest
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] returnValue = new int[nums.Length];

            int product = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i];
                returnValue[i] = product;
            }

            product = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                returnValue[i] = product * (i == 0 ? 1 : returnValue[i - 1]);
                product *= nums[i];
            }

            return returnValue;
        }
    }
}

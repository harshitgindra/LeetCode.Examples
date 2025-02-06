namespace LeetCode.MediumProblems
{
    public class Maximum_Product_Subar
    {
        public int MaxProduct(int[] nums)
        {
            int returnValue = nums[0];

            int currentValue = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                currentValue *= nums[i];
                if (currentValue > returnValue)
                {
                    returnValue = currentValue;
                }
                if (currentValue == 0)
                {
                    currentValue = 1;
                }
            }

            currentValue = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                currentValue *= nums[i];
                if (currentValue > returnValue)
                {
                    returnValue = currentValue;
                }
                if (currentValue == 0)
                {
                    currentValue = 1;
                }
            }
            return returnValue;
        }
    }
}

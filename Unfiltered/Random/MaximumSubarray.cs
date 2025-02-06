namespace LeetCode
{
    public class MaximumSubarray
    {
        public MaximumSubarray()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Maximum Subarray");
            Console.WriteLine("----------------------------------------------------------");
        }

        public int MaxSubArray(int[] nums)
        {
            //***
            //*** Set the maximum value as array's first element
            //***
            int returnValue = nums[0];
            int numLength = nums.Length;
            for (int i = 0; i < numLength; i++)
            {
                int baseNumber = nums[i];
                for (int j = i; j < numLength; j++)
                {
                    //***
                    //*** If first loop and second loop index is same, compare the value
                    //*** If array value is greater than maximum value, update the return value
                    //***
                    if (i == j)
                    {
                        if (returnValue < baseNumber)
                        {
                            returnValue = baseNumber;
                        }
                    }
                    else
                    {
                        //***
                        //*** Add the number to the base number and compare to the maximum value
                        //*** If greater, update the maximum value
                        //***
                        baseNumber += nums[j];
                        if (returnValue < baseNumber)
                        {
                            returnValue = baseNumber;
                        }
                    }
                }
            }

            return returnValue;
        }
    }
}
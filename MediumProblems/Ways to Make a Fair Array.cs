namespace LeetCode.MediumProblems
{
    public class Ways_to_Make_a_Fair_Array
    {
        public int WaysToMakeFair(int[] nums) 
        { 
            if(nums == null || nums.Length == 0) return 0;
        
            int numberOfIndexChosen = 0;
        
            int[] evenLeft = new int[nums.Length];
            int[] oddLeft = new int[nums.Length];
            int[] evenRight = new int[nums.Length];
            int[] oddRight  =new int[nums.Length];
        
            // computing even left and odd left from left to right
            int even = 0,odd = 0;
            for(int i = 0 ; i < nums.Length ; i++)
            {
                evenLeft[i] = even;
                oddLeft[i] = odd;
                if(i % 2 == 0)
                {
                    even += nums[i];
                }
                else
                {
                    odd += nums[i];
                }
            }
            even = 0;
            odd = 0;
            // computing even right and odd right going from right to left
            for(int i = nums.Length-1 ; i >= 0 ; i--)
            {
                evenRight[i] = even;
                oddRight[i] = odd;
                if(i % 2 == 0)
                {
                    even += nums[i];
                }
                else
                {
                    odd += nums[i];
                }
            }
        
            // Final step of verification
            for(int i = 0 ; i < nums.Length ; i++)
            {
                if(evenLeft[i] + oddRight[i] == oddLeft[i] + evenRight[i])
                {
                    numberOfIndexChosen++;
                }
            }       
            return numberOfIndexChosen;
        }
    }
}
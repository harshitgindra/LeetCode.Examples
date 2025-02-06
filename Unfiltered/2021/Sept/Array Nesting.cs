namespace LeetCode.Problems._2021.Sept
{
    /// <summary>
    /// https://leetcode.com/problems/array-nesting/
    /// </summary>
    class Array_Nesting
    {
        public int ArrayNesting(int[] nums)
        {
            //***
            //*** Initialize the array with all false
            //***
            bool[] isVisited = new bool[nums.Length];
            int returnValue = 0;
            //***
            //*** Iterate through all the elements in the array
            //***
            for (int i = 0; i < nums.Length; i++)
            {
                //***
                //*** If the element is already visited
                //*** We do not have to continue with the index as the result will be less than the previous calculation
                //***
                if (!isVisited[i])
                {
                    int start = nums[i];
                    int count = 0;
                    //***
                    //*** Run the loop until we find the element matching nums[i]
                    //***
                    do
                    {
                        start = nums[start];
                        count++;
                        isVisited[start] = true;
                    }
                    while (start != nums[i]);
                    //***
                    //*** Compare the count with returnValue and save the higher value
                    //***
                    returnValue = Math.Max(returnValue, count);
                }
            }
            return returnValue;
        }
    }
}

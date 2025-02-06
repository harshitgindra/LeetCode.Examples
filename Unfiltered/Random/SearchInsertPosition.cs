namespace LeetCode
{
    public class SearchInsertPosition
    {
        public SearchInsertPosition()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Search Insert Position");
            Console.WriteLine("----------------------------------------------------------");
        }

        public int SearchInsert(int[] nums, int target)
        {
            int returnValue = 0;
            foreach (var num in nums)
            {
                //***
                //*** If target is less than or equal to current number 
                //***
                if (target <= num)
                {
                    break;
                }
                returnValue++;
            }

            return returnValue;
        }
    }
}
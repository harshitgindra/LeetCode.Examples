namespace LeetCode.EasyProblems
{
    class Largest_Number_At_Least_Twice_of_Others
    {

        public int DominantIndex(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            else if (nums.Length > 1)
            {
                int[] ret = nums.ToArray();

                Array.Sort(ret);

                int max = ret[nums.Length - 1];

                if (max >= ret[nums.Length - 2] * 2)
                {
                    return Array.IndexOf(nums, max);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }

        }
    }
}

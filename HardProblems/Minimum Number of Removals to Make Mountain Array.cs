using LeetCode.SharedUtils;


namespace LeetCode.Hard
{
    public class Minimum_Number_of_Removals_to_Make_Mountain_Array
    {
        public int MinimumMountainRemovals(int[] nums)
        {
            bool isIncreasing = false;
            int ret = 0;
            int start = nums[0];
            int topIndex = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > start)
                {
                    isIncreasing = true;
                    start = nums[i];
                }
                else
                {
                    if (isIncreasing)
                    {
                        //*** top reached
                        topIndex = i;
                        break;
                    }
                    else
                    {
                        ret++;
                        start = nums[i];
                    }
                }
            }
            
            

            return ret;
        }

        [Test(Description = "https://leetcode.com/problems/add-two-numbers-ii/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Add Two Numbers II")]
        [TestCaseSource(nameof(Input))]
        public void Test1((ListNode Output, int[] Input) item)
        {
            var response = MinimumMountainRemovals(item.Input);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(ListNode Output, int[] Input)> Input
        {
            get
            {
                return new List<(ListNode Output, int[] Input)>()
                {
                    (null, new int[] {2, 1, 1, 5, 6, 2, 3, 1})
                };
            }
        }
    }
}


namespace LeetCode.Problems._2021.Nov
{
    public class Maximum_Subarray
    {
        public int MaxSubArray(int[] nums)
        {
            int returnValue = Int32.MinValue;

            if (nums != null && nums.Length > 0)
            {
                int temp = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > temp + nums[i])
                    {
                        temp = nums[i];
                    }
                    else
                    {
                        temp += nums[i];
                    }
                    returnValue = Math.Max(returnValue, temp);
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/maximum-subarray/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Maximum Subarray")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaxSubArray(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (6, new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}),
                };
            }
        }
    }
}
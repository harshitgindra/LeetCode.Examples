using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Minimum_Size_Subarray_Sum
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            var n = nums.Length;

            var global = int.MaxValue;

            var sum = 0;
            var left = 0;
            for (int right = 0; right < n; right++)
            {
                sum += nums[right];

                if (sum >= s)
                {
                    while (sum >= s)
                    {
                        sum -= nums[left];
                        left++;
                    }
                    if (sum < s)
                    {
                        left--;
                        sum += nums[left];
                    }

                    var local = right - left + 1;

                    global = Math.Min(global, local);
                }
            }

            return global == int.MaxValue ? 0 : global;
        }

        [Test(Description = "https://leetcode.com/problems/minimum-size-subarray-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Minimum Size Subarray Sum")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (int, int[]) Input) item)
        {
            var response = MinSubArrayLen(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int, int[]))> Input
        {
            get
            {
                return new List<(int Output, (int, int[]))>()
                {
                    (3, (11, new int[] { 1,2,3,4,5})),
                };
            }
        }
    }
}

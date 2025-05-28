namespace LeetCode.MediumProblems
{
    class MinimumSizeSubarraySum
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            int minLength = int.MaxValue;
            int windowSum = 0;
            int windowStart = 0;

            // Slide windowEnd across the array
            foreach (int windowEnd in nums.Select((num, index) => index))
            {
                windowSum += nums[windowEnd];

                // Shrink window from left while sum >= target
                while (windowSum >= target)
                {
                    minLength = Math.Min(minLength, windowEnd - windowStart + 1);
                    windowSum -= nums[windowStart];
                    windowStart++;
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
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
                    (3, (11, new int[] { 1, 2, 3, 4, 5 })),
                };
            }
        }
    }
}
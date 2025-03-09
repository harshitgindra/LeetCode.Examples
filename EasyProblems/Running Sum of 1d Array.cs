using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Running_Sum_of_1d_Array
    {
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }

            return nums;
        }

        [Test(Description = "https://leetcode.com/problems/running-sum-of-1d-array/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Running Sum of 1d Array")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = RunningSum(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input =>
            new List<(int[] Output, int[] Input)>()
            {
                ([1, 3, 6, 10], ( [1, 2, 3, 4])),
            };
    }
}
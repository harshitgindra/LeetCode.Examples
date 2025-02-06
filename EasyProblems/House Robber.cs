using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class House_Robber
    {
        public int ThreeSumTest(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int[] ans = new int[nums.Length];
            ans[0] = nums[0];
            ans[1] = Math.Max(nums[1], nums[0]);

            for (int i = 2; i < nums.Length; i++)
            {
                ans[i] = Math.Max(nums[i] + ans[i - 2], ans[i - 1]);
            }

            return ans[nums.Length - 1];
        }

        [Test(Description = "https://leetcode.com/problems/house-robber/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("House Robber")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = ThreeSumTest(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (4, new int[] {2,1,1,2}),
                    (4, new int[] {1,2,3,1}),
                    (12, new int[] {2,7,9,3,1}),
                };
            }
        }
    }
}

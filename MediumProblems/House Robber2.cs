using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    public class House_Robber2
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            return Math.Max(Rob(nums, 0, nums.Length - 1), Rob(nums, 1, nums.Length - 1));
        }

        public int Rob(int[] nums, int start, int end)
        {
            int previousLevel1 = 0;
            int previousLevel2 = 0;
            int current = 0;
            for (int i = start; i <= end; i++)
            {
                current = Math.Max(nums[i] + previousLevel2, previousLevel1);
                previousLevel2 = previousLevel1;
                previousLevel1 = current;
            }

            return current;
        }

        [Test(Description = "https://leetcode.com/problems/house-robber-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("House Robber 2")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = Rob(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (4, [1, 2, 3, 1]),
                (3, [1, 2, 1, 1]),
            };
    }
}


namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/single-number/
    /// </summary>
    public class Single_Number
    {
        public int SingleNumber(int[] nums)
        {

            if (nums == null || nums.Length % 2 == 0)
            {
                return 0;
            }

            int result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }

            return result;
        }

        [Test(Description = "https://leetcode.com/problems/single-number/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Single Number")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = SingleNumber(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (4, [4, 1, 2, 1, 2]),
            };
    }
}

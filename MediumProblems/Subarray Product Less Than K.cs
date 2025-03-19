

namespace LeetCode.MediumProblems
{
    class Subarray_Product_Less_Than_K
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            return 0;
        }

        [Test(Description = "https://leetcode.com/problems/subarray-product-less-than-k/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Subarray Product Less Than K")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = this.NumSubarrayProductLessThanK(item.Input.Item1, item.Input.Item2);
            // Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input =>
            new List<(int Output, (int[], int) Input)>()
            {
                (8, ([10, 5, 2, 6],100)),
            };
    }
}

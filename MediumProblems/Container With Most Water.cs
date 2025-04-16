namespace LeetCode.MediumProblems
{
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int returnValue = 0;

            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                int distance = right - left;
                int minHeight = Math.Min(height[left], height[right]);
                int currentProduct = distance * minHeight;
                returnValue = Math.Max(returnValue, currentProduct);

                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/container-with-most-water/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Container With Most Water")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaxArea(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (49, [1, 8, 6, 2, 5, 4, 8, 3, 7])
            };
    }
}
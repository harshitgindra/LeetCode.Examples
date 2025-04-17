namespace LeetCode.MediumProblems
{
    class TwoSumIiInputArrayIsSorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target) break;
                if (sum < target) left++;
                if (sum > target) right--;
            }

            return [left + 1, right + 1];
        }

        [Test(Description = "https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Two Sum II - Input array is sorted")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, (int[] numbers, int target) Input) item)
        {
            var response = TwoSum(item.Input.numbers, item.Input.target);
            Assert.That(item.Output, Is.EqualTo(response));
        }

        public static IEnumerable<(int[] Output, (int[] numbers, int target) Input)> Input =>
            new List<(int[] Output, (int[] numbers, int target) Input)>()
            {
                ([1, 2], ([2, 7, 11, 15], 9)),
            };
    }
}
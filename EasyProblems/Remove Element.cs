

namespace LeetCode.EasyProblems
{
    class Remove_Element
    {
        public int RemoveElement(int[] nums, int val)
        {
            int j = 0;

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != val) {
                    nums[j] = nums[i];
                    j++;
                }
            }

            return j;
        }

        [Test(Description = "https://leetcode.com/problems/remove-element/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Remove Element")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = RemoveElement(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input =>
            new List<(int Output, (int[], int) Input)>()
            {

                (2, ([3,2,2,3], 3)),
                (5, ([0,1,2,2,3,0,4,2], 2)),
            };
    }
}

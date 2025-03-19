

namespace LeetCode.EasyProblems
{
    class Third_Maximum_Number
    {
        public int ThirdMax(int[] nums)
        {
            var hashset = nums.ToHashSet().OrderByDescending(x => x);

            if (hashset.Count() >= 3)
            {
                return hashset.Take(3).Last();
            }
            else
            {
                return hashset.First();
            }
        }

        [Test(Description = "https://leetcode.com/problems/third-maximum-number/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Third Maximum Number")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = ThirdMax(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (1, ( [3, 2, 1])),
                (2, ( [1, 2])),
                (1, ( [2, 2, 3, 1])),
            };
    }
}
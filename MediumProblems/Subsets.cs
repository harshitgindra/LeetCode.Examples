

namespace LeetCode.MediumProblems
{
    class SubsetsTest
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>()
            {
                new List<int>()
            };
            IList<int> combo = new List<int>();

            for (int i = 1; i <= nums.Length; i++)
            {
                Sort(result, combo, nums, i, 0);
            }

            return result;
        }

        private void Sort(IList<IList<int>> result, IList<int> combo, int[] nums, int remaining, int index)
        {
            if (remaining == 0)
            {
                result.Add(combo.ToList());
            }
            else
            {
                for (int i = index; i <= nums.Length - remaining; i++)
                {
                    combo.Add(nums[i]);
                    Sort(result, combo, nums, remaining - 1, i + 1);
                    combo.Remove(nums[i]);
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/subsets/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Subsets")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = Subsets(item.Input);
            ClassicAssert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (8, new int[] {1,2,3}),
                };
            }
        }
    }
}

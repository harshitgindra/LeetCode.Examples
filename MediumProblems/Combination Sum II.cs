

namespace LeetCode.MediumProblems
{
    class Combination_Sum_II
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> records = new List<IList<int>>();

            _Helper(0, target, candidates, new List<int>(), records);
            return records;
        }


        private void _Helper(int startIndex, int target, int[] candidates,
            IList<int> combo, IList<IList<int>> records)
        {
            if (target == 0)
            {
                records.Add(combo);
            }
            else
            {
                int lastValue = 0;
                for (int i = startIndex; i < candidates.Length; i++)
                {
                    if (candidates[i] > target)
                    {
                        break;
                    }

                    if (candidates[i] != lastValue)
                    {
                        lastValue = candidates[i];
                        combo.Add(lastValue);
                        _Helper(i + 1, target - lastValue, candidates, combo.ToList(), records);
                        combo.RemoveAt(combo.Count - 1);
                    }
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Combination Sum II")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = CombinationSum2(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (4, (new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8)),
                    (2, (new int[] { 2, 5, 2, 1, 2 }, 5)),
                };
            }
        }
    }
}
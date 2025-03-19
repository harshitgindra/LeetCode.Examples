

namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/combination-sum/
    /// </summary>
    class Combination_Sum
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> result = new List<IList<int>>();

            Helper(candidates, 0, 0, new List<int>(), result, target);
            return result;
        }


        private void Helper(int[] candidates, int index, int sum, IList<int> nums, IList<IList<int>> result, int target)
        {
            if (index < candidates.Length)
            {
                int temp = candidates[index] + sum;
                if (temp > target)
                {
                    // sum greater than target
                    // break the loop as we all the remaining candidates will also be higher
                }
                else if (temp == target)
                {
                    // Combination found
                    // Add to result
                    nums.Add(candidates[index]);
                    result.Add(nums.ToList());
                    nums.RemoveAt(nums.Count - 1);
                    // break the loop as all numbers after this will be higher
                }
                else
                {
                    // split the flow
                    // Flow 1: add the current number 
                    nums.Add(candidates[index]);
                    Helper(candidates, index, temp, nums, result, target);
                    nums.RemoveAt(nums.Count - 1);

                    // Flow 2: Do not add the current number, skip to next number
                    Helper(candidates, index + 1, sum, nums, result, target);
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Combination Sum")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = CombinationSum(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (2, (new int[] {2, 3, 6, 7}, 7)),
                    (3, (new int[] {2, 3, 5}, 8)),
                };
            }
        }
    }
}
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class SubsetsTest2
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IDictionary<string, IList<int>> result = new Dictionary<string, IList<int>>()
            {
                {"", new List<int>() }
            };
            IList<int> combo = new List<int>();
            Array.Sort(nums);
            for (int i = 1; i <= nums.Length; i++)
            {
                Sort(result, combo, nums, i, 0, new StringBuilder());
            }

            return result.Values.ToList();
        }

        private void Sort(IDictionary<string, IList<int>> result, IList<int> combo, int[] nums, int remaining, int index, StringBuilder key)
        {
            if (remaining == 0)
            {
                string tempKey = key.ToString();
                if (!result.ContainsKey(tempKey))
                {
                    result.Add(tempKey, combo.ToList());
                }
            }
            else
            {
                for (int i = index; i <= nums.Length - remaining; i++)
                {
                    string numStr = $"{nums[i]}";
                    combo.Add(nums[i]);
                    key.Append(numStr);
                    Sort(result, combo, nums, remaining - 1, i + 1, key);
                    combo.Remove(nums[i]);
                    key.Remove(key.Length - numStr.Length, numStr.Length);
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/subsets-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Subsets II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = SubsetsWithDup(item.Input);
            ClassicAssert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (6, new int[] {1,2,2}),
                    (8, new int[] {-1,1,2}),
                };
            }
        }
    }
}

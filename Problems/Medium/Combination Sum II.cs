using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Combination_Sum_II
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IDictionary<string, IList<int>> records = new Dictionary<string, IList<int>>();

            IList<int> combo = new List<int>();
            Combine(0, target, candidates, combo, records);

            return records.Values.ToList();
        }


        private void Combine(int startIndex, int target, int[] candidates,
            IList<int> combo
            , IDictionary<string, IList<int>> records)
        {
            if (target == 0)
            {
                var tempCombo = combo.ToArray();
                var key = string.Join("", tempCombo);
                if (!records.ContainsKey(key))
                {
                    records.Add(key, tempCombo);
                }
            }
            else
            {
                for (int i = startIndex; i < candidates.Length; i++)
                {
                    if (target >= candidates[i])
                    {
                        combo.Add(candidates[i]);
                        Combine(i + 1, target - candidates[i], candidates, combo, records);
                        combo.RemoveAt(combo.Count - 1);
                    }
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Combination Sum II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = CombinationSum2(item.Input.Item1, item.Input.Item2);
             Assert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {

                    (4, (new int[] {10,1,2,7,6,1,5}, 8)),
                    (2, (new int[] {2,5,2,1,2}, 5)),
                };
            }
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Combination_Sum4
    {
        public int CombinationSum4(int[] nums, int target)
        {
            return Combine(0, target, nums, 0);
        }


        private int Combine(int startIndex, int target, int[] candidates,
             int records)
        {
            if (target == 0)
            {
                return records + 1;
            }
            else
            {
                for (int i = startIndex; i < candidates.Length; i++)
                {
                    if (target >= candidates[i])
                    {
                        records = Combine(0, target - candidates[i], candidates, records);
                    }
                }
                return records;
            }
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Combination Sum")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = CombinationSum4(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {

                    (7, (new int[] {1, 2, 3}, 4)),
                    (39882198, (new int[] {4,2,1}, 32)),
                };
            }
        }
    }
}

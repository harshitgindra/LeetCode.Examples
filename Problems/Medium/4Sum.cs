using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    public class _4Sum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums != null && nums.Length > 3)
            {
                HashSet<(int, int, int, int)> ret = new HashSet<(int, int, int, int)>();
                Array.Sort(nums);
                Add(ret, new List<int>(), nums, 0, 0, target);
                List<IList<int>> t = new List<IList<int>>();
                t.AddRange(ret.Select(i => new List<int>{
                                            i.Item1,
                                            i.Item2,
                                            i.Item3,
                                            i.Item4
                                        }));
                return t;
            }
            else
            {
                return new List<IList<int>>();
            }
        }

        private void Add(HashSet<(int, int, int, int)> result, IList<int> record, int[] nums, int startIndex, int currentTarget, int target)
        {
            if (record.Count == 4 && currentTarget == target)
            {
                result.Add((record[0], record[1], record[2], record[3]));
            }
            else if (record.Count == 4)
            {
                return;
            }
            else if (record.Count == 3 && result.Any(x => x.Item1 == record[0]
             && x.Item2 == record[1]
             && x.Item3 == record[2]))
            {
                return;
            }
            else if(record.Count < 4)
            {
                for (int i = startIndex; i < nums.Length + record.Count - 3; i++)
                {
                    record.Add(nums[i]);

                    Add(result, record, nums, i + 1, currentTarget + nums[i], target);

                    record.RemoveAt(record.Count - 1);
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/4sum/submissions/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("4Sum")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = FourSum(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, (int[], int))> Input
        {
            get
            {
                return new List<(int Output, (int[], int))>()
                {
                    //(1, (new int[] {2,1,0,-1}, 2)),
                    (3, (new int[] {1,0,-1,0,-2,2}, 0)),
                };
            }
        }
    }
}

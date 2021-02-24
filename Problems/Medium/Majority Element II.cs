using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Majority_Element_II
    {
        public IList<int> MajorityElement(int[] nums)
        {
            HashSet<int> results = new HashSet<int>();

            if (nums != null)
            {
                Array.Sort(nums);

                int lastValue = 0;

                int counter = 0;
                int benchmark = nums.Length / 3;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == lastValue)
                    {
                        counter++;
                    }
                    else
                    {
                        if (counter > benchmark)
                        {
                            results.Add(lastValue);
                        }
                        lastValue = nums[i];
                        counter = 1;
                    }
                }

                if (counter > benchmark)
                {
                    results.Add(lastValue);
                }
            }
            return results.ToList();
        }

        [Test(Description = "https://leetcode.com/problems/majority-element-ii/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Majority Element II")]
        [TestCaseSource("Input")]
        public void Test1((IList<int> Output, int[] Input) item)
        {
            var response = MajorityElement(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(IList<int> Output, int[] Input)> Input
        {
            get
            {
                return new List<(IList<int> Output, int[] Input)>()
                {

                    (new List<int>(){ 3}, new int[]{ 3,2,3}),
                    (new List<int>(){ 1,2}, new int[]{1,1,1,3,3,2,2,2})
                };
            }
        }
    }
}

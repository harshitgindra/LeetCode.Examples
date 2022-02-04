using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    class Find_All_Numbers_Disappeared_in_an_Array
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var recs = Enumerable.Range(1, nums.Length).Except(nums)
                .ToList();

            return recs;
        }

        [Test(Description = "https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Find All Numbers Disappeared in an Array")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = FindDisappearedNumbers(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {
                    (new int[]{ 5,6}, new int[] { 4,3,2,7,8,2,3,1 })
                };
            }
        }
    }
}

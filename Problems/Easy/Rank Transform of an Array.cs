using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    class Rank_Transform_of_an_Array
    {

        public int[] ArrayRankTransform(int[] arr)
        {
            var sortedArr = arr.Distinct().ToArray();
            Array.Sort(sortedArr);

            int i = 1;
            var hashset = sortedArr.ToDictionary(x => x, y => i++);

            int[] returnvalue = new int[arr.Length];

            for (int j = 0; j < arr.Length; j++)
            {
                returnvalue[j] = hashset[arr[j]];
            }
            return returnvalue;
        }


        [Test(Description = "https://leetcode.com/problems/rank-transform-of-an-array/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Rank Transform of an Array")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = ArrayRankTransform(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {

                    (new int[]{4,1,2,3 }, new int[]{ 40,10,20,30}),
                    (new int[]{1,1,1 }, new int[]{ 100,100,100}),
                    (new int[]{5,3,4,2,8,6,7,1,3 }, new int[]{ 37,12,28,9,100,56,80,5,12})
                };
            }
        }
    }
}

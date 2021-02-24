using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Remove_Covered_Intervals
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {

            int[] recs = new int[1001];

            foreach (var item in intervals)
            {
                for (int j = item[0]; j <= item[1]; j++)
                {
                    recs[j]++;
                }
            }

            IList<int[]> dict = intervals.OrderBy(x => x[0]).ToList();

            var i = 0;
            int returnValue = dict.Count;
            while (i < dict.Count)
            {
                var item = dict[i];

                if (recs[item[0]] > 1 && recs[item[1]] > 1)
                {
                    for (int j = item[0]; j <= item[1]; j++)
                    {
                        recs[j]++;
                    }
                    returnValue--;
                    dict.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            intervals = dict.ToArray();
            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/remove-covered-intervals/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Remove Covered Intervals")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[][] Input) item)
        {
            var response = RemoveCoveredIntervals(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[][] Input)> Input
        {
            get
            {
                return new List<(int Output, int[][] Input)>()
                {

                    (2, new int[][]{new int[]{ 1,4 }, new int[]{ 3,6 }, new int[]{ 2,8 } }),

                };
            }
        }
    }
}

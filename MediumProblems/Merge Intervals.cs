using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    class Merge_Intervals
    {
        public int[][] Merge(int[][] intervals)
        {
            List<int[]> ret = new List<int[]>();
            //***
            //*** Order the results by first element and then by second
            //***
            intervals = intervals.OrderBy(x => x[0])
                .ThenBy(x=>x[1])
                .ToArray();

            var i = intervals[0][0];
            var j = intervals[0][1];

            for (int k = 1; k < intervals.Length; k++)
            {
                var item = intervals[k];

                //***
                //*** If first element is less than previous second element
                //***
                if (item[0] <= j)
                {
                    //***
                    //*** if second element is greater than previous second element
                    //***
                    if (item[1] > j)
                    {
                        //***
                        //*** Override the second element with current element
                        //***
                        j = item[1];
                    }
                }
                else
                {
                    ret.Add(new int[] { i, j });

                    i = item[0];
                    j = item[1];
                }
            }

            ret.Add(new int[] { i, j });

            return ret.ToArray();
        }

        [Test(Description = "https://leetcode.com/problems/merge-intervals/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Merge Intervals")]
        [TestCaseSource("Input")]
        public void Test1((int[][] Output, int[][] Input) item)
        {
            var response = Merge(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[][] Output, int[][])> Input
        {
            get
            {
                return new List<(int[][] Output, int[][])>()
                {
                    (new int[][]
                        {
                            new int[]{1,6},
                            new int[]{8,10},
                            new int[]{15,18},
                        }
                    , new int[][]
                    {
                        new int[]{1,3},
                        new int[]{2,6},
                        new int[]{8,10},
                        new int[]{15,18},
                    }),
                };
            }
        }
    }
}

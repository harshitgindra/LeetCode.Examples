

namespace LeetCode.Problems._2021.Nov
{
    public class Interval_List_Intersections
    {
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            var results = new List<int[]>();

            int firstPointer = 0, secondPointer = 0;
            while (firstPointer < firstList.Length &&
                   secondPointer < secondList.Length)
            {
                var first = firstList[firstPointer];
                var second = secondList[secondPointer];

                if (first[0] <= second[1]
                    && first[1] >= second[0])
                {
                    results.Add(new int[]
                    {
                        Math.Max(first[0], second[0]),
                        Math.Min(first[1], second[1]),
                    });
                }
                else  if (second[0] <= first[1]
                          && second[1] >= first[0])
                {
                    results.Add(new int[]
                    {
                        Math.Max(first[0], second[0]),
                        Math.Min(first[1], second[1]),
                    });
                }

                if (second[1] >= first[1])
                {
                    firstPointer++;
                }
                if (first[1] >= second[1])
                {
                    secondPointer++;
                }
            }

            return results.ToArray();
        }

        [Test(Description =
            "https://leetcode.com/problems/interval-list-intersections/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Interval List Intersections")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[][] Output, (int[][] firstList, int[][] secondList) Input) item)
        {
            var response = IntervalIntersection(item.Input.firstList, item.Input.secondList);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[][] Output, (int[][] firstList, int[][] secondList) Input)> Input
        {
            get
            {
                return new List<(int[][] Output, (int[][] firstList, int[][] secondList) Input)>()
                {
                    (new int[][]
                    {
                        new int[]{1,2},
                        new int[]{5,5},
                        new int[]{8,10},
                        new int[]{15,23},
                        new int[]{24,24},
                        new int[]{25,25},
                    }
                        , (new int[][]
                    {
                        new int[]{0,2},
                        new int[]{5,10},
                        new int[]{13,23},
                        new int[]{24,25}
                    },
                        new int[][]
                        {
                            new int[]{1,5},
                            new int[]{8,12},
                            new int[]{15,24},
                            new int[]{25,26}
                        })),
                };
            }
        }
    }
}
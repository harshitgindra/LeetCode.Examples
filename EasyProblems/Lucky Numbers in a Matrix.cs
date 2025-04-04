﻿

namespace LeetCode.EasyProblems
{
    public class Lucky_Numbers_in_a_Matrix
    {
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            HashSet<int> xMin = new HashSet<int>();
            IDictionary<int, int> yMax = new Dictionary<int, int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                var item = matrix[i];
                int minValue = Int32.MaxValue;

                for (int j = 0; j < item.Length; j++)
                {
                    var jValue = item[j];
                    if (yMax.ContainsKey(j))
                    {
                        yMax[j] = Math.Max(yMax[j], jValue);
                    }
                    else
                    {
                        yMax.Add(j, jValue);
                    }

                    minValue = Math.Min(minValue, jValue);
                }

                xMin.Add(minValue);
            }

            return yMax.Values.Intersect(xMin).ToList();
        }

        [Test(Description = "https://leetcode.com/problems/lucky-numbers-in-a-matrix/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Lucky Numbers in a Matrix")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<int> Output, int[][] Input) item)
        {
            var response = LuckyNumbers(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(IList<int> Output, int[][] Input)> Input
        {
            get
            {
                return new List<(IList<int> Output, int[][] Input)>()
                {
                    (new List<int>() { 15 },
                        new[] { new[] { 3, 7, 8 }, new[] { 9, 11, 13 }, new[] { 15, 16, 17 } }),

                    (new List<int>() { 12 },
                        new[]
                        {
                            [1, 10, 4, 2], new[] { 9, 3, 8, 7 }, new[] { 15, 16, 17, 12 }
                        }),
                };
            }
        }
    }
}
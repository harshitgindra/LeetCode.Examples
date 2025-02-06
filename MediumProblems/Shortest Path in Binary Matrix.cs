using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Shortest_Path_in_Binary_Matrix
    {
        int min = Int32.MaxValue;
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int iMax = grid.Length;
            int jMax = grid[0].Length;

            List<(int, int)> list = new List<(int, int)>
            {
                (1, 1),
                (1, -1),

                (-1, -1),
                (-1, 1),
                (0, 1),
                (0, -1),
                (1, 0),
                (-1, 0),
            };
            var response = Next(grid, iMax, jMax, 0, 0, 1, Int32.MaxValue, list);

            if (response.Item2)
            {
                return min;
            }
            else
            {
                return -1;
            }
        }

        private (int, bool) Next(int[][] grid, int iMax, int jMax, int i, int j, int steps, int minSteps,
            List<(int, int)> list)
        {
            if (i < 0 || j < 0 || i >= iMax || j >= jMax || grid[i][j] != 0)
            {
                return (steps, false);
            }
            else if (i == iMax - 1 && j == jMax - 1)
            {
                min = Math.Min(steps, min);
                return (Math.Min(steps, minSteps), true);
            }
            else
            {
                grid[i][j] = -1;
                bool found = false;
                int tempSteps = minSteps;
                foreach (var item in list)
                {
                    var newI = i + item.Item1;
                    var newJ = j + item.Item2;

                    var response = Next(grid, iMax, jMax, newI, newJ, steps + 1, tempSteps, list);
                    if (response.Item2)
                    {
                        found = true;
                        tempSteps = response.Item1;
                    }
                }

                return (tempSteps, found);
            }
        }

        [Test(Description = "https://leetcode.com/problems/shortest-path-in-binary-matrix/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Course Schedule II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[][] Input) item)
        {
            var response = ShortestPathBinaryMatrix(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[][] Input)> Input
        {
            get
            {
                return new List<(int Output, int[][] Input)>()
                {
                    (4, new int[][]
                    {
                        new int[] {0, 0, 0},
                        new int[] {1, 1, 0},
                        new int[] {1, 1, 0},
                    }),
                };
            }
        }
    }
}
using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Diagonal_Traverse
    {
        public int[] FindDiagonalOrder(int[][] matrix)
        {
            var row = matrix.Length;
            if (row == 0) return new int[0];
            var col = matrix[0].Length;

            var result = new List<int>();

            var count = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == 0 || j == col - 1)
                    {
                        var oneResult = new List<int>();

                        var curI = i;
                        var curJ = j;

                        while (curI < row && curJ >= 0)
                        {
                            oneResult.Add(matrix[curI][curJ]);
                            curI++;
                            curJ--;
                        }

                        if (count % 2 == 0)
                        {
                            oneResult.Reverse();
                        }

                        count++;

                        result.AddRange(oneResult);
                    }
                }
            }

            return result.ToArray();
        }



        [Test(Description = "https://leetcode.com/problems/diagonal-traverse/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Minimum Size Subarray Sum")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[][] Input) item)
        {
            var response = FindDiagonalOrder(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[] Output, int[][])> Input
        {
            get
            {
                return new List<(int[] Output, int[][])>()
                {
                    (new int[]{ 1,2,4,7,5,3,6,8,9}, new int[][] { new int[]{ 1,2,3},
                    new int[]{ 4,5,6},
                    new int[]{ 7,8,9}}),
                };
            }
        }
    }
}

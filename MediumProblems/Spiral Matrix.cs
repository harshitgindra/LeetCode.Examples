using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Spiral_Matrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> ret = new List<int>();
            if (matrix != null && matrix.Length > 0)
            {
                int m = matrix.Length;
                int n = matrix[0].Length;
                int topRow = 0;
                int rightColumn = n - 1;
                int bottomRow = m - 1;
                int leftColumn = 0;
                int dir = 1;


                while (ret.Count < m * n)
                {
                    //***
                    //*** Top row left to right
                    //***
                    if (dir == 1)
                    {
                        var row = matrix[topRow];
                        for (int i = leftColumn; i <= rightColumn; i++)
                        {
                            ret.Add(row[i]);
                        }
                        topRow++;
                        dir = 2;
                    }
                    //***
                    //*** Left column top to bottom
                    //***
                    else if (dir == 2)
                    {
                        for (int i = topRow; i <= bottomRow; i++)
                        {
                            ret.Add(matrix[i][rightColumn]);
                        }
                        rightColumn--;

                        dir = 3;
                    }
                    //***
                    //*** Bottom row right to left
                    //***
                    else if (dir == 3)
                    {
                        var row = matrix[bottomRow];
                        for (int i = rightColumn; i >= leftColumn; i--)
                        {
                            ret.Add(row[i]);
                        }
                        bottomRow--;
                        dir = 4;
                    }
                    //***
                    //*** Left column bottom to top
                    //***
                    else if (dir == 4)
                    {
                        for (int i = bottomRow; i >= topRow; i--)
                        {
                            ret.Add(matrix[i][leftColumn]);
                        }
                        leftColumn++;

                        dir = 1;
                    }
                }
            }
            return ret;
        }


        [Test(Description = "https://leetcode.com/problems/spiral-matrix/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Longest Palindromic Substring")]
        [TestCaseSource("Input")]
        public void Test1((List<int> Output, int[][] Input) item)
        {
            var response = SpiralOrder(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(List<int> Output, int[][] Input)> Input
        {
            get
            {
                return new List<(List<int> Output, int[][] Input)>()
                {
                    (new List<int>(){ 1,2,3,6,9,8,7,4,5},                    new int[][]{
                        new int[]{ 1, 2, 3 },
                        new int[]{ 4,5,6 },
                        new int[]{ 7, 8, 9 }
                        }),
                };
            }
        }
    }
}

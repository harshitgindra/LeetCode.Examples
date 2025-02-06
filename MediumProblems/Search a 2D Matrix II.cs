namespace LeetCode.MediumProblems
{
    class Search_a_2D_Matrix_II
    {
        private HashSet<int> _nums;
        public bool SearchMatrix(int[,] matrix, int target)
        {
            _nums = new HashSet<int>();
            var response = Search(matrix, target, 0, 0, matrix.GetLength(0), matrix.GetLength(1));
            return response;
        }

        private bool Search(int[,] matrix, int target, int i, int j, int iMax, int jMax)
        {
            bool returnValue = false;
            if (i < 0 || j < 0 || i >= iMax || j >= jMax)
            {
                returnValue = false;
            }
            else
            {
                if (matrix[i, j] == target)
                {
                    return true;
                }
                else if (_nums.Contains(matrix[i, j]))
                {
                    return false;
                }
                else
                {
                    _nums.Add(matrix[i, j]);
                    if (matrix[i, j] > target)
                    {
                        //***
                        //*** Go up
                        //***
                        returnValue = Search(matrix, target, i - 1, j, iMax, jMax);
                        if (!returnValue)
                        {
                            //***
                            //*** Go left
                            //***
                            returnValue = Search(matrix, target, i, j - 1, iMax, jMax);
                        }
                    }
                    else
                    {
                        //***
                        //*** Go diagonal
                        //***
                        returnValue = Search(matrix, target, i + 1, j + 1, iMax, jMax);

                        if (!returnValue)
                        {
                            //***
                            //*** Go right
                            //***
                            returnValue = Search(matrix, target, i, j + 1, iMax, jMax);
                        }

                        if (!returnValue)
                        {
                            //***
                            //*** Go down
                            //***
                            returnValue = Search(matrix, target, i + 1, j, iMax, jMax);
                        }
                    }
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/search-a-2d-matrix-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Search a 2D Matrix II")]
        [TestCaseSource("Input")]
        public void Test1((List<int> Output, int[,] Input) item)
        {
            var response = SearchMatrix(item.Input, 20);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(List<int> Output, int[,] Input)> Input
        {
            get
            {
                return new List<(List<int> Output, int[,] Input)>()
                {
                    (null,                    new int[,] { { 1, 4, 7, 11, 15 },
                        { 2,5,8,12,19 }, { 3,6,9,16,22 }, { 10,13,14,17,24 } }),
                };
            }
        }
    }
}

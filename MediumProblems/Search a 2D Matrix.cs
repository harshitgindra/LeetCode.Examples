namespace LeetCode.MediumProblems
{
    class SearchA2DMatrix
    {
        // Searches for a target value in a 2D matrix using binary search
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int left = 0, right = rows * cols - 1;

            // Binary search over the "flattened" matrix
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                // Map mid to 2D indices
                int midValue = matrix[mid / cols][mid % cols];

                if (midValue == target)
                    return true;
                else if (midValue < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/search-a-2d-matrix/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Search a 2D Matrix")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, (int[][], int) Input) item)
        {
            var response = this.SearchMatrix(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(bool Output, (int[][], int) Input)> Input
        {
            get
            {
                return new List<(bool Output, (int[][], int) Input)>()
                {
                    (true, (new int[1][]
                    {
                        [1, 3],
                    }, 3)),
                    (true, (new int[3][]
                    {
                        [1, 3, 5, 7],
                        [10, 11, 16, 20],
                        [23, 30, 34, 60],
                    }, 30)),
                };
            }
        }
    }
}
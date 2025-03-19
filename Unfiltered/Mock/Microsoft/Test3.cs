

namespace LeetCode.Mock.Microsoft
{
    class Test3
    {
        public bool RotateString(string A, string B)
        {
            if (A.Length == B.Length)
            {
                B = B + B;
                if (B.Contains(A))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public IList<int> MajorityElement(int[] nums)
        {
            int benchmark = nums.Length / 3;
            IList<int> ret = new List<int>();

            Array.Sort(nums);
            int prev = nums[0];
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == prev)
                {
                    count++;
                }
                else
                {
                    if (count > benchmark)
                    {
                        ret.Add(prev);
                    }
                    count = 1;
                    prev = nums[i];
                }
            }

            if (count > benchmark)
            {
                ret.Add(prev);
            }

            return ret;
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Mock Test")]
        [Category("Combination Sum")]
        [TestCaseSource(nameof(Input))]
        public void Test1((List<int> Output, int[] Input) item)
        {
            var response = MajorityElement(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(List<int> Output, int[] Input)> Input
        {
            get
            {
                return new List<(List<int> Output, int[] Input)>()
                {
                     (new List<int>{ 3}, new int[]{ 3,2,3}),

                };
            }
        }

        public bool WordPattern(string pattern, string s)
        {
            var arry = s.Split(" ");

            if (pattern.Length != arry.Length)
            {
                return false;
            }

            var dict = new Dictionary<char, string>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (dict.ContainsKey(pattern[i]))
                {
                    if (dict[pattern[i]] != arry[i])
                    {
                        return false;
                    }
                }
                else if (dict.Values.Contains(arry[i]))
                {
                    return false;
                }
                else
                {
                    dict.Add(pattern[i], arry[i]);
                }
            }

            return true;
        }

        public int[][] UpdateMatrix(int[][] matrix)
        {
            int iMax = matrix.Length - 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                var item = matrix[i];
                int jMax = item.Length - 1;

                for (int j = 0; j < item.Length; j++)
                {
                    if (item[j] == 1)
                    {
                        var a = Up(matrix, i, j, iMax, jMax);
                        var b = Down(matrix, i, j, iMax, jMax);
                        var c = Right(matrix, i, j, iMax, jMax);
                        var d = Left(matrix, i, j, iMax, jMax);
                        if (a > 0 && b > 0 && c > 0 && d > 0)
                        {
                            var max = Math.Max(a, Math.Max(b, Math.Max(c, d)));
                            matrix[i][j] = max;
                        }
                    }
                }
            }

            return matrix;
        }

        private int Up(int[][] nums, int i, int j, int iMax, int jMax)
        {
            if (i > 0)
            {
                if (nums[i - 1][j] > 0)
                {
                    return nums[i - 1][j];
                }
            }
            return 1;
        }

        private int Down(int[][] nums, int i, int j, int iMax, int jMax)
        {
            if (i < iMax)
            {
                if (nums[i + 1][j] > 0)
                {
                    return nums[i + 1][j];
                }
            }
            return 1;
        }

        private int Right(int[][] nums, int i, int j, int iMax, int jMax)
        {
            if (j < jMax)
            {
                if (nums[i][j + 1] > 0)
                {
                    return nums[i][j + 1];
                }
            }
            return 1;
        }

        private int Left(int[][] nums, int i, int j, int iMax, int jMax)
        {
            if (j > 0)
            {
                if (nums[i][j - 1] > 0)
                {
                    return nums[i][j - 1];
                }
            }
            return 1;
        }

    }
}

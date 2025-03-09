namespace LeetCode.MediumProblems
{
    public class Spiral_Matrix_II
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] returnValue = new int[n][];
            for (int i = 0; i < n; i++)
            {
                returnValue[i] = new int[n];
            }

            Update(returnValue, 0, 0, n - 1, n - 1, 1, n);
            return returnValue;
        }

        private void Update(int[][] result, int i, int j, int iMax, int jMax, int lastNum, int n)
        {
            while (i <= iMax || j <= jMax)
            {
                //***
                //*** Go right
                //***
                for (int tempj = j; tempj <= jMax; tempj++)
                {
                    result[i][tempj] = lastNum++;
                }

                i++;

                //***
                //*** Go down
                //***
                for (int temp = i; temp <= iMax; temp++)
                {
                    result[temp][jMax] = lastNum++;
                }

                jMax--;


                //***
                //*** Go left
                //***
                for (int temp = jMax; temp >= j; temp--)
                {
                    result[iMax][temp] = lastNum++;
                }

                iMax--;

                //***
                //*** Go up
                //***
                for (int temp = iMax; temp >= i; temp--)
                {
                    result[temp][j] = lastNum++;
                }

                j++;
            }
        }


        [Test(Description = "https://leetcode.com/problems/string-compression/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("String Compression")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int Input) item)
        {
            var response = GenerateMatrix(item.Input);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int Input)> Input
        {
            get
            {
                return new List<(int Output, int Input)>()
                {
                    (6, 3),
                };
            }
        }
    }
}
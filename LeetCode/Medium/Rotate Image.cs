using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Rotate_Image
    {
        public void Rotate(int[][] matrix)
        {
            int[][] response = new int[matrix.Length][];
            var iMax = matrix.Length - 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                var item = matrix[i];
                for (int j = 0; j < item.Length; j++)
                {
                    if (response[iMax - i] == null)
                    {
                        response[iMax - i] = new int[matrix.Length];
                    }

                    if (response[j] == null)
                    {
                        response[j] = new int[matrix.Length];
                    }

                    response[j][iMax - i] = item[j];
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = response[i];
            }

            matrix = response;
        }

        [Test(Description = "https://leetcode.com/problems/rotate-image/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Rotate Image")]
        [TestCaseSource("Input")]
        public void Test1((int[][] Output, int[][] Input) item)
        {
            Rotate(item.Input);
            Assert.AreEqual(item.Output, item.Input);
        }

        public static IEnumerable<(int[][] Output, int[][] Input)> Input
        {
            get
            {
                return new List<(int[][] Output, int[][] Input)>()
                {

                    (new int[][]{new int[]{ 7,4,1 }, new int[]{8,5,2 }, new int[]{ 9,6,3 } },
                    new int[][]{new int[]{ 1,2,3 }, new int[]{4,5,6 }, new int[]{ 7,8,9 } }),
                };
            }
        }
    }
}

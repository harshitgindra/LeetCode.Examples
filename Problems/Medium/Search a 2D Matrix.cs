using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Search_a_2D_Matrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null)
            {
                return false;
            }
            int iMax = matrix.Length;
            int jMax = 0;
            if (iMax > 0)
            {
                jMax = matrix[0].Length;
            }
            int i = 0, j = 0;

            while (i < iMax && j < jMax)
            {
                if (matrix[i][j] == target)
                {
                    return true;
                }
                else if (matrix[i][j] > target)
                {
                    return false;
                }
                else
                {
                    if (matrix[i][matrix[i].Length - 1] < target)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/search-a-2d-matrix/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Search a 2D Matrix")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (int[][], int) Input) item)
        {
            var response = this.SearchMatrix(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (int[][], int) Input)> Input
        {
            get
            {
                return new List<(bool Output, (int[][], int) Input)>()
                {
                     (true, (new int[1][]{
                    new int[]{ 1,3},
                        },3)),
                    (true, (new int[3][]{
                    new int[]{ 1,3,5,7},
                    new int[]{ 10,11,16,20},
                    new int[]{ 23,30,34,60},
                        },30)),
                };
            }
        }
    }
}

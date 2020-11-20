using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Hard
{
    public class Maximal_Rectangle
    {
        public int MaximalRectangle(char[][] matrix)
        {
            int ret = 0;
            if (matrix != null && matrix.Length > 0)
            {
                int iMax = matrix.Length;
                int jMax = matrix[0].Length;

                int[][] dp = new int[iMax][];

                for (int i = 0; i < iMax; i++)
                {
                    dp[i] = new int[jMax];
                    for (int j = 0; j < jMax; j++)
                    {
                        dp[i][j] = matrix[i][j] - '0';
                        if (dp[i][j] == 1)
                        {
                            ret = 1;
                        }
                    }
                }

                int[] arry = new int[jMax];

                for (int k = 0; k < iMax; k++)
                {
                    for (int j = 0; j < jMax; j++)
                    {
                        if (dp[k][j] == 0)
                        {
                            arry[j] = 0;
                        }
                        else
                        {
                            arry[j] += dp[k][j];
                        }
                    }

                    int prev = arry[0];
                    for (int i = 0; i < arry.Length; i++)
                    {
                        ret = Math.Max(ret, arry[i]);
                        int minHeight = arry[i];
                        int width = 1;
                        for (int j = i - 1; j >= 0; j--)
                        {
                            width++;
                            minHeight = Math.Min(arry[j], minHeight);
                            ret = Math.Max(ret, minHeight * width);
                        }
                    }
                }
            }

            return ret;
        }

        [Test(Description = "https://leetcode.com/problems/maximal-rectangle/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("maximal rectangle")]
        [TestCaseSource("Input")]
        public void Test1((int Output, char[][] Input) item)
        {
            var response = MaximalRectangle(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, char[][] Input)> Input
        {
            get
            {
                return new List<(int Output, char[][] Input)>()
                {
                    (4, new char[][]
                    {
                        new char[] {'0', '1'},
                        new char[] {'1', '0'},
                    }),
                    (4, new char[][]
                    {
                        new char[] {'1', '0', '1', '0', '0'},
                        new char[] {'1', '0', '1', '1', '1'},
                        new char[] {'1', '1', '1', '1', '1'},
                        new char[] {'1', '0', '1', '0', '0'},
                        new char[] {'1', '0', '0', '1', '0'},
                    }),
                };
            }
        }
    }
}
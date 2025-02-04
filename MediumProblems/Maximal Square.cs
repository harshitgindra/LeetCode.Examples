using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    public class Maximal_Square
    {
        public int MaximalSquare(char[][] matrix)
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

                for (int i = 1; i < iMax; i++)
                {
                    for (int j = 1; j < jMax; j++)
                    {
                        if (dp[i][j] == 1)
                        {
                            var min = Math.Min(Math.Min(dp[i - 1][j - 1], dp[i - 1][j]), dp[i][j - 1]) + 1;
                            ret = Math.Max(min, ret);
                            dp[i][j] = min;
                        }
                    }
                }
            }
            
            return ret * ret;
        }

        [Test(Description = "https://leetcode.com/problems/3sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("maximal square")]
        [TestCaseSource("Input")]
        public void Test1((int Output, char[][] Input) item)
        {
            var response = MaximalSquare(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, char[][] Input)> Input
        {
            get
            {
                return new List<(int Output, char[][] Input)>()
                {
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
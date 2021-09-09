using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.Sept
{
    /// <summary>
    /// https://leetcode.com/problems/largest-plus-sign/
    /// </summary>
    class Largest_Plus_Sign
    {
        public int OrderOfLargestPlusSign(int n, int[][] mines)
        {
            int returnValue = 0;

            //***
            //*** Initialize the dp
            //***
            var dp = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new bool[n];
            }

            //***
            //*** Add mines
            //***
            foreach (var item in mines)
            {
                dp[item[0]][item[1]] = true;
            }

            var leftToRight = LeftToRight(dp, n);
            var rightToLeft = RightToLeft(dp, n);
            var topToBottom = TopToBottom(dp, n);
            var bottomToTop = BottomToTop(dp, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var slotMin = Math.Min(leftToRight[i][j], Math.Min(rightToLeft[i][j], Math.Min(topToBottom[i][j], bottomToTop[i][j])));
                    returnValue = Math.Max(returnValue, slotMin);
                }
            }


            return returnValue;
        }

        private int[][] LeftToRight(bool[][] dp, int n)
        {
            var leftToRight = new int[n][];
            for (int i = 0; i < n; i++)
            {
                leftToRight[i] = new int[n];
                int counter = 0;
                for (int j = 0; j < n; j++)
                {
                    if (dp[i][j])
                    {
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                    }
                    leftToRight[i][j] = counter;
                }
            }

            return leftToRight;
        }

        private int[][] RightToLeft(bool[][] dp, int n)
        {
            var rightToLeft = new int[n][];
            for (int i = 0; i < n; i++)
            {
                rightToLeft[i] = new int[n];
                int counter = 0;
                for (int j = n - 1; j >= 0; j--)
                {
                    if (dp[i][j])
                    {
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                    }
                    rightToLeft[i][j] = counter;
                }
            }

            return rightToLeft;
        }

        private int[][] TopToBottom(bool[][] dp, int n)
        {
            var topToBottom = new int[n][];
            for (int i = 0; i < n; i++)
            {
                topToBottom[i] = new int[n];
            }

            for (int i = 0; i < n; i++)
            {
                int counter = 0;
                for (int j = 0; j < n; j++)
                {
                    if (dp[j][i])
                    {
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                    }
                    topToBottom[j][i] = counter;
                }
            }

            return topToBottom;
        }

        private int[][] BottomToTop(bool[][] dp, int n)
        {
            var bottomToTop = new int[n][];
            for (int i = 0; i < n; i++)
            {
                bottomToTop[i] = new int[n];
            }

            for (int i = 0; i < n; i++)
            {
                int counter = 0;
                for (int j = n - 1; j >= 0; j--)
                {
                    if (dp[j][i])
                    {
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                    }
                    bottomToTop[j][i] = counter;
                }
            }

            return bottomToTop;
        }

        [Test(Description = "https://leetcode.com/problems/largest-plus-sign/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Largest plus sign")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int n, int[][] mines) Input) item)
        {
            var response = OrderOfLargestPlusSign(item.Input.n, item.Input.mines);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int n, int[][] mines) Input)> Input
        {
            get
            {
                return new List<(int Output, (int n, int[][] mines) Input)>()
                {
                    (0,(2, new int[][]{
                        new int[]{0,0 } ,
                        new int[]{0,1 } ,
                        new int[]{1,0 } ,
                        new int[]{1,1 } ,
                        })),
                    (2,(5, new int[][]{ new int[]{4,2 } })),
                };
            }
        }
    }
}

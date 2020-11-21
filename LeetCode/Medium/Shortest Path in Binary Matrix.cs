using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Medium
{
    class Shortest_Path_in_Binary_Matrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int iMax = grid.Length;
            int jMax = grid.GetLength(0);
            int ret = 1;

            int i = 0;
            int j = 0;
            while (i < iMax && j < jMax)
            {

                //**
                //** Diagonal
                //**
                if (i + 1 < iMax && j + 1 < jMax)
                {
                    if (grid[i + 1][j + 1] == 0)
                    {
                        i++;
                        j++;
                        continue;
                    }
                }

                //**
                //** Right
                //**
                if (i < iMax && j + 1 < jMax)
                {
                    if (grid[i + 1][j + 1] == 0)
                    {
                        i++;
                        j++;
                        continue;
                    }
                }
            }

            return 0;
        }

        //private (int, bool) Next(int[][] grid, int iMax, int jMax, int i, int j, )
        //{

        //}

        [Test(Description = "https://leetcode.com/problems/course-schedule-ii/")]
        [Category("Hard")]
        [Category("Leetcode")]
        [Category("Course Schedule II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[][] Input) item)
        {
            var response = ShortestPathBinaryMatrix(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[][] Input)> Input
        {
            get
            {
                return new List<(int Output, int[][] Input)>()
                {
                    (4, new int[][]
                    {
                        new int[]{0,0,0},
                        new int[]{1,1,0},
                        new int[]{1,1,0},
                    }),
                };
            }
        }
    }
}

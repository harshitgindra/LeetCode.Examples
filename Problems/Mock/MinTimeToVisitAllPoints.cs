using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Mock
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-time-visiting-all-points/submissions/
    /// </summary>
    class MinTimeToVisitAllPointsTest
    {
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int seconds = 0;
            for (int i = 0; i < points.Length - 1; i++)
            {
                var currPoint = points[i];
                var nextPoint = points[i + 1];

                seconds += GetSeconds(currPoint[0], currPoint[1], nextPoint[0], nextPoint[1], 0);
            }

            return seconds;
        }

        private int GetSeconds(int x1, int y1, int x2, int y2, int seconds)
        {
            if (x1 == x2 && y1 == y2)
            {
                //***
                //*** point met
                //***
            }
            else if (x1 != x2 && y1 != y2)
            {
                //***
                //*** Diagonal
                //***
                if (x2 > x1 && y2 > y1)
                {
                    seconds = GetSeconds(x1 + 1, y1 + 1, x2, y2, seconds + 1);
                }
                else if (x2 < x1 && y2 < y1)
                {
                    seconds = GetSeconds(x1 - 1, y1 - 1, x2, y2, seconds + 1);
                }
                else if (x2 > x1 && y2 < y1)
                {
                    seconds = GetSeconds(x1 + 1, y1 - 1, x2, y2, seconds + 1);
                }
                else if (x2 < x1 && y2 > y1)
                {
                    seconds = GetSeconds(x1 - 1, y1 + 1, x2, y2, seconds + 1);
                }
            }
            else
            {
                //***
                //*** Either x or y point is same, need to travel horizontal or vertical
                //***
                if (x1 == x2)
                {
                    if (y2 > y1)
                    {
                        seconds = GetSeconds(x1, y1 + 1, x2, y2, seconds + 1);
                    }
                    else
                    {
                        seconds = GetSeconds(x1, y1 - 1, x2, y2, seconds + 1);
                    }
                }
                else
                {
                    if (x2 > x1)
                    {
                        seconds = GetSeconds(x1 + 1, y1, x2, y2, seconds + 1);
                    }
                    else
                    {
                        seconds = GetSeconds(x1 - 1, y1, x2, y2, seconds + 1);
                    }
                }
            }

            return seconds;
        }
    }
}

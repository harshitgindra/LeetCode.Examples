using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Leetcode.Problems._2022.January
{
    public class Minimum_Number_of_Arrows_to_Burst_Balloons
    {
        public int FindMinArrowShots(int[][] points)
        {
            int arrows = 0;

            if (points.Length == 0)
            {
                arrows = 0;
            }
            else if (points.Length == 1)
            {
                arrows++;
            }
            else
            {
                int currentReach = Int32.MinValue;

                foreach (var item in points.OrderBy(x => x[1]))
                {
                    if (currentReach < item[0])
                    {
                        arrows++;
                        currentReach = item[1];
                    }
                }
            }

            return arrows;
        }
    }
}
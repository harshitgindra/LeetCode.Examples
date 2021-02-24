using System;

namespace LeetCode.Hard
{
    /// <summary>
    /// https://leetcode.com/problems/largest-rectangle-in-histogram/
    /// </summary>
    public class Largest_Rectangle_in_Histogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            int ret = 0;
            if (heights != null && heights.Length > 0)
            {
                ret = heights[0];
                for (int i = 1; i < heights.Length; i++)
                {
                    ret = Math.Max(ret, heights[i]);
                    int minHeight = heights[i];
                    int width = 1;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        width++;
                        minHeight = Math.Min(heights[j], minHeight);
                        ret = Math.Max(ret, minHeight * width);
                    }
                }

            }
            return ret;
        }
    }
}
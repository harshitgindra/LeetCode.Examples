using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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
                Stack<int> stacks = new Stack<int>();
                stacks.Push(0);
                int i = 0;
                for (i = 1; i < heights.Length; i++)
                {
                    if (stacks.Any())
                    {
                        if (heights[i] < heights[stacks.Peek()])
                        {
                            while (stacks.Any() && heights[stacks.Peek()] > heights[i])
                            {
                                ret = Math.Max(ret, Helper(stacks, heights, i));
                            }
                        }
                    }

                    stacks.Push(i);
                }

                while (stacks.Any())
                {
                    ret = Math.Max(ret, Helper(stacks, heights, i));
                }
            }

            return ret;
        }

        private int Helper(Stack<int> stack, int[] heights, int i)
        {
            int topElementIndex = stack.Pop();
            if (stack.Any())
            {
                return heights[topElementIndex] * (i - stack.Peek() - 1);
            }
            else
            {
                return heights[topElementIndex] * i;
            }
        }

        [Test(Description = "https://leetcode.com/problems/largest-rectangle-in-histogram/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Largest Rectangle in Histogram")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = LargestRectangleArea(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (5, new int[] {2, 1, 2, 3, 1}),
                    (4, new int[] {1, 2, 3}),
                };
            }
        }

        public int LargestRectangleArea2(int[] heights)
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
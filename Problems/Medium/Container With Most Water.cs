using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Medium
{
    [TestFixture]
    public class Container_With_Most_Water
    {
        public int MaxArea(int[] height)
        {
            int maxArea = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {
                int firstLineHeight = height[i];
                for (int j = i+1 ; j < height.Length; j++)
                {
                    int secondLineHeight = height[j];

                    var area = (j - i) * (Math.Min(firstLineHeight, secondLineHeight));
                    maxArea = Math.Max(area, maxArea);
                }
            }

            return maxArea;
        }

        [Test(Description = "https://leetcode.com/problems/container-with-most-water/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Container With Most Water")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaxArea(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (49, new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 })
                };
            }
        }
    }
}

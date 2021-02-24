using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    public class Height_Checker
    {
        public int HeightChecker(int[] heights)
        {
            var tempHeights = heights.ToArray();
            Array.Sort(tempHeights);

            int returnValue = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != tempHeights[i])
                {
                    returnValue++;
                }
            }
            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/height-checker/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Height Cracker")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = HeightChecker(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (3, new int[]{1,1,4,2,1,3 }),
                    (5, new int[]{5,1,2,3,4 }),
                    (0, new int[]{1,2,3,4, 5 }),
                };
            }
        }
    }
}

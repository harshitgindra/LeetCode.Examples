using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Maximize_Distance_to_Closest_Person
    {
        public int MaxDistToClosest(int[] seats)
        {
            int returnValue = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                int left = 0;
                int lIndex = i;
                if (seats[i] == 0)
                {
                    // check left
                    while (lIndex != 0)
                    {

                    }
                }
            }
            return 0;
        }

        [Test(Description = "https://leetcode.com/problems/3sum/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("3Sum")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaxDistToClosest(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (2, new int[]{ 1,0,0,0,1,0,1}),
                    (3, new int[]{ 1,0,0,0}),
                    (1, new int[]{ 0,1})
                };
            }
        }
    }
}

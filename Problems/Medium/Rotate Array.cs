using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Rotate_Array
    {
        public void Rotate(int[] nums, int k)
        {
            IDictionary<int, int> calc = new Dictionary<int, int>();
            int nLength = nums.Length;
            for (int i = 0; i < nLength; i++)
            {
                int newPosition = (i + k);
                while (newPosition >= nLength)
                {
                    newPosition = Math.Abs(newPosition - nLength);
                }

                calc.Add(newPosition, nums[i]);
            }

            foreach (var item in calc)
            {
                nums[item.Key] = item.Value;
            }
        }

        [Test(Description = "https://leetcode.com/problems/rotate-array/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Rotate Array")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, (int[], int) Input) item)
        {
            Rotate(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, item.Input.Item1);
        }

        public static IEnumerable<(int[] Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int[] Output, (int[], int) Input)>()
                {

                    (new int[]{ 5,6,7,1,2,3,4}, (new int[]{ 1,2,3,4,5,6,7}, 3)),
                };
            }
        }
    }
}

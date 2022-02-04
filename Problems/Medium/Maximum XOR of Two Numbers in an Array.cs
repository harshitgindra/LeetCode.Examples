using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    public class Maximum_XOR_of_Two_Numbers_in_an_Array
    {
        public int FindMaximumXOR(int[] nums)
        {
            int returnValue = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    returnValue = Math.Max(returnValue, nums[i] ^ nums[j]);
                }
            }
            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Maximum XOR of Two Numbers in an Array")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindMaximumXOR(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (28, new int[] { 3, 10, 5, 25, 2, 8}),
                };
            }
        }
    }
}

﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Subarray_Product_Less_Than_K
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            return 0;
        }

        [Test(Description = "https://leetcode.com/problems/subarray-product-less-than-k/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Subarray Product Less Than K")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = this.NumSubarrayProductLessThanK(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (8, (new int[]{ 10, 5, 2, 6},100)),
                };
            }
        }
    }
}

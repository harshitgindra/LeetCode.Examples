﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode.Hard
{
    public class Count_of_Smaller_Numbers_After_Self
    {
        public IList<int> CountSmaller(int[] nums)
        {
            var sortedNums = new List<int>();
            var result = new int[nums.Length];

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int left = 0;
                int right = sortedNums.Count;

                while (left < right)
                {
                    var mid = left + (right - left) / 2;
                    if (sortedNums[mid] >= nums[i]) right = mid;
                    else left = mid + 1;
                }

                result[i] = left;
                sortedNums.Insert(left, nums[i]);
            }

            return result;
        }

        [Test(Description = "https://leetcode.com/problems/count-of-smaller-numbers-after-self/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Count of Smaller Numbers After Self")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = CountSmaller(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {

                    (new int[]{2,1,1,0}, (new int[] {5,2,6,1})),
                };
            }
        }
    }
}

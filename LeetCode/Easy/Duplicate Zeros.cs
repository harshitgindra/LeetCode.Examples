using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Duplicate_Zeros
    {
        public void DuplicateZeros(int[] arr)
        {
            int index = 0;
            while (index < arr.Length - 1)
            {
                if (arr[index] == 0)
                {
                    int tempIndex = arr.Length - 2;

                    while (tempIndex > index)
                    {
                        arr[tempIndex + 1] = arr[tempIndex];
                        tempIndex--;
                    }
                    index++;
                    arr[index] = 0;
                }
                index++;
            }
        }

        [Test(Description = "https://leetcode.com/problems/duplicate-zeros/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Duplicate Zeros")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            DuplicateZeros(item.Input);
            Assert.AreEqual(item.Output, item.Input);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {

                    (new int[]{ 1,0,0,2,3,0,0,4}, new int[]{ 1,0,2,3,0,4,5,0}),
                    (new int[]{ 1,2,3}, new int[]{ 1,2,3}),
                    (new int[]{ 0,0,0,0,0,0,0}, new int[]{ 0,0,0,0,0,0,0}),
                };
            }
        }
    }
}

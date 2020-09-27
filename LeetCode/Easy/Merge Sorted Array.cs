using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Merge_Sorted_Array
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int num2Index = 0;
            for (int i = m; i < nums1.Length; i++)
            {
                nums1[i] = nums2[num2Index];
                num2Index++;
            }

            Array.Sort(nums1);
        }


        [Test(Description = "https://leetcode.com/problems/merge-sorted-array/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Merge Sorted Array")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, (int[], int, int[], int) Input) item)
        {
            Merge(item.Input.Item1, item.Input.Item2, item.Input.Item3, item.Input.Item4);
            Assert.AreEqual(item.Output, item.Input.Item1);
        }

        public static IEnumerable<(int[] Output, (int[], int, int[], int) Input)> Input
        {
            get
            {
                return new List<(int[] Output, (int[], int, int[], int) Input)>()
                {

                    (new int[]{ 1,2,2,3,5,6}, (new int[]{ 1,2,3,0,0,0}, 3,new int[]{ 2,5,6},3)),
                };
            }
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/valid-mountain-array/
    /// </summary>
    class Valid_Mountain_Array
    {
    
        public bool ValidMountainArray(int[] A)
        {
            int highestIndex = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                var item1 = A[i];
                var item2 = A[i + 1];
                if (item1 == item2)
                {
                    return false;
                }

                if (item1 > item2)
                {
                    highestIndex = i;
                    break;
                }
            }

            if (highestIndex == 0 || highestIndex == A.Length -1)
            {
                return false;
            }

            for (int i = highestIndex; i < A.Length - 1; i++)
            {
                var item1 = A[i];
                var item2 = A[i + 1];
                if (item1 == item2 || item2 > item1)
                {
                    return false;
                }
            }

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/valid-mountain-array/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Valid Mountain Array")]
        [Category("Jan-2022")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, int[] Input) item)
        {
            var response = ValidMountainArray(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, int[] Input)> Input
        {
            get
            {
                return new List<(bool Output, int[] Input)>()
                {

                    (true, (new int[] {0,3,2,1})),
                    (false, (new int[] {3,5,5})),
                };
            }
        }
    }
}

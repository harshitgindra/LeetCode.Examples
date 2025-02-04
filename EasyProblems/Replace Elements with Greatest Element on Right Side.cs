using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    class Replace_Elements_with_Greatest_Element_on_Right_Side
    {

        public int[] ReplaceElements(int[] arr)
        {
            int[] returnValue = new int[arr.Length];
            returnValue[arr.Length - 1] = -1;

            int prevMax = -1;
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                prevMax = returnValue[i] = Math.Max(arr[i + 1], prevMax);
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/replace-elements-with-greatest-element-on-right-side/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Replace Elements with Greatest Element on Right Side")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = ReplaceElements(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {

                    (new int[]{ 18,6,6,6,1,-1}, (new int[] {17,18,5,4,6,1})),
                };
            }
        }
    }
}

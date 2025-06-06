﻿

namespace LeetCode.MediumProblems
{
    class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] returnValue = new int[nums.Length];

            int product = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i];
                returnValue[i] = product;
            }

            product = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                returnValue[i] = product * (i == 0 ? 1 : returnValue[i - 1]);
                product *= nums[i];
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/product-of-array-except-self/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Product of Array Except Self")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = ProductExceptSelf(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input =>
            new List<(int[] Output, int[] Input)>()
            {
                ([24, 12, 8, 6], [1, 2, 3, 4]),
                // (null, new int[0]),
                // (null, new int[] { 0 }),
            };
    }
}
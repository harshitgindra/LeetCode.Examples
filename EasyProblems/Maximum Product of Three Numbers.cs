

namespace LeetCode.EasyProblems
{
    class Maximum_Product_of_Three_Numbers
    {
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int nLength = nums.Length;
            var result = Math.Max(nums[0] * nums[1] * nums[nLength - 1],
                nums[nLength - 3] * nums[nLength - 2] * nums[nLength - 1]);


            //var result = Sum(0, 3, nums, 1, Int32.MinValue);
            return result;
        }

        private int Sum(int start, int numLength, int[] nums, int product, int maxProduct)
        {
            if (numLength != 0)
            {
                for (int i = start; i < nums.Length; i++)
                {
                    int tempProduct = product * nums[i];
                    maxProduct = Sum(i + 1, numLength - 1, nums, tempProduct, maxProduct);
                }
            }
            else
            {
                maxProduct = Math.Max(product, maxProduct);
            }

            return maxProduct;
        }

        [Test(Description = "https://leetcode.com/problems/maximum-product-of-three-numbers/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Maximum Product of Three Numbers")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaximumProduct(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (126, [7, 3, 1, 0, 0, 6]),
                    (-6, [-1, -2, -3]),
                    (24, [1, 2, 3, 4]),
                    (6, [-1, -2, 1, 2, 3]),
                };
            }
        }
    }
}
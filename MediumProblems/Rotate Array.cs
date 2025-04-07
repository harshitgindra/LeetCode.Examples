

namespace LeetCode.MediumProblems
{
    class Rotate_Array
    {
        public void Rotate(int[] nums, int k)
        {
            if (nums != null && nums.Length > 0 && k > 0)
            {
                k = k % nums.Length;

                //***
                //*** Reverse the entire array
                //***
                Array.Reverse(nums);
                //***
                //*** Reverse the array from  0 to k
                //***
                Helper(nums, 0, k - 1);
                //***
                //*** Reverse the array from  k to the end of array
                //***
                Helper(nums, k, nums.Length - 1);
            }
        }

        private void Helper(int[] arry, int start, int end)
        {
            while (start < end)
            {
                int temp = arry[start];
                arry[start] = arry[end];
                arry[end] = temp;
                start++;
                end--;
            }
        }

        [Test(Description = "https://leetcode.com/problems/rotate-array/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Rotate Array")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, (int[], int) Input) item)
        {
            Rotate(item.Input.Item1, item.Input.Item2);
            Assert.That(item.Input.Item1, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, (int[], int) Input)> Input =>
            new List<(int[] Output, (int[], int) Input)>()
            {
                ([5, 6, 7, 1, 2, 3, 4], ([1, 2, 3, 4, 5, 6, 7], 3)),
            };
    }
}
using NUnit.Framework.Legacy;

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

        public void Rotate2(int[] nums, int k)
        {
            IDictionary<int, int> calc = new Dictionary<int, int>();
            int nLength = nums.Length;
            for (int i = 0; i < nLength; i++)
            {
                int newPosition = (i + k);
                while (newPosition >= nLength)
                {
                    newPosition = Math.Abs(newPosition - nLength);
                }

                calc.Add(newPosition, nums[i]);
            }

            foreach (var item in calc)
            {
                nums[item.Key] = item.Value;
            }
        }

        [Test(Description = "https://leetcode.com/problems/rotate-array/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Rotate Array")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, (int[], int) Input) item)
        {
            Rotate(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, item.Input.Item1);
        }

        public static IEnumerable<(int[] Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int[] Output, (int[], int) Input)>()
                {
                    (new int[] {5, 6, 7, 1, 2, 3, 4}, (new int[] {1, 2, 3, 4, 5, 6, 7}, 3)),
                };
            }
        }
    }
}
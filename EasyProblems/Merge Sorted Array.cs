using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Merge_Sorted_Array
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int returnArrayCounter = nums1.Length -1;
            int num1Counter = m - 1;
            int num2Counter = n - 1;

            while (num1Counter >= 0 || num2Counter >= 0)
            {
                if (num1Counter >= 0 && num2Counter >= 0)
                {
                    if (nums1[num1Counter] > nums2[num2Counter])
                    {
                        nums1[returnArrayCounter] = nums1[num1Counter];
                        num1Counter--;
                    }
                    else
                    {
                        nums1[returnArrayCounter] = nums2[num2Counter];
                        num2Counter--;
                    }
                } else if (num1Counter >= 0)
                {
                    nums1[returnArrayCounter] = nums1[num1Counter];
                    num1Counter--;
                } else
                {
                    nums1[returnArrayCounter] = nums2[num2Counter];
                    num2Counter--;
                }

                returnArrayCounter--;
            }
        }


        [Test(Description = "https://leetcode.com/problems/merge-sorted-array/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Merge Sorted Array")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, (int[], int, int[], int) Input) item)
        {
            Merge(item.Input.Item1, item.Input.Item2, item.Input.Item3, item.Input.Item4);
            ClassicAssert.AreEqual(item.Output, item.Input.Item1);
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

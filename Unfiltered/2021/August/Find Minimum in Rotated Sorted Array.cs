using NUnit.Framework.Legacy;

namespace LeetCode.Problems._2021.August
{
    class Find_Minimum_in_Rotated_Sorted_Array
    {
        public int FindMin(int[] nums)
        {
            int returnValue = -1;

            if (nums != null)
            {
                //***
                //*** Initialize variables
                //***
                returnValue = Int32.MaxValue;
                int left = 0;
                int right = nums.Length - 1;
                //***
                //*** Run the loop until left is less than or equal to right
                //***
                while (left <= right)
                {
                    //***
                    //*** Calculate the mid index
                    //***
                    int mid = left + (right - left) / 2;
                    //***
                    //*** Mid value in nums is less than right value
                    //*** We will update the right index to mid - 1
                    //***
                    if (nums[mid] < nums[right])
                    {
                        right = mid - 1;
                        returnValue = Math.Min(nums[mid], returnValue);
                    }
                    //***
                    //*** Mid value in nums is equal to or greater than right value
                    //*** We will update the left index to mid + 1
                    //***
                    else
                    {
                        left = mid + 1;
                        returnValue = Math.Min(nums[right], returnValue);
                    }
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Find Minimum in Rotated Sorted Array")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindMin(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (1, new int[]{3,1,2 }),
                };
            }
        }
    }
}

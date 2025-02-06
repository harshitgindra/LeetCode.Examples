using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Set_Mismatch
    {
        public int[] FindErrorNums(int[] nums)
        {
            var returnValue = new int[2];
            foreach (var item in nums)
            {
                var i = Math.Abs(item);
                if (nums[i - 1] < 0)
                {
                    returnValue[0] = i;
                }
                else
                {
                    nums[i - 1] = nums[i - 1] * -1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    returnValue[1] = i + 1;
                    break;
                }
            }
            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/set-mismatch/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Set Mismatch")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = FindErrorNums(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {
                    (new int[]{2,3 }, new int[] {1,2,2,4}),
                };
            }
        }
    }
}

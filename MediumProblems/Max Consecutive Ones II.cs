using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Max_Consecutive_Ones_II
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int retValue = 0;

            if (nums != null && nums.Length > 0)
            {
                if (nums.Any(x => x == 0))
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (nums[i] == 0)
                        {
                            nums[i] = 1;
                            retValue = Math.Max(retValue, GetOnes(nums, i));
                            nums[i] = 0;
                        }
                    }
                }
                else
                {
                    retValue = nums.Length;
                }
            }

            return retValue;
        }

        private int GetOnes(int[] nums, int index)
        {
            int ret = 1;
            int i = index - 1;
            while (i >= 0)
            {
                if (nums[i] == 1)
                {
                    i--;
                    ret++;
                }
                else
                {
                    break;
                }
            }

            i = index + 1;
            while (i < nums.Length)
            {
                if (nums[i] == 1)
                {
                    i++;
                    ret++;
                }
                else
                {
                    break;
                }
            }

            return ret;
        }



        [Test(Description = "https://leetcode.com/problems/max-consecutive-ones-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Max Consecutive Ones II")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindMaxConsecutiveOnes(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (4, new int[] {1,0,1,1,0}),
                };
            }
        }
    }
}

using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class ThreeSum_Closest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            int closestSum = Int32.MaxValue;
            int minDiff = Int32.MaxValue;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int firstNum = nums[i];
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    int secondNum = nums[j];
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        int sum = nums[k] + firstNum + secondNum;
                        int tempDifference = (sum) - target;

                        if (Math.Abs(tempDifference) < Math.Abs(minDiff))
                        {
                            minDiff = tempDifference;
                            closestSum = sum;
                        }
                    }
                }
            }


            return closestSum;
        }


        [Test(Description = "https://leetcode.com/problems/3sum-closest/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("3Sum Closest")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = ThreeSumClosest(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {

                    (3, (new int[] {1,1,-1,-1,3}, 3)),
                    (2, (new int[] {1,1,1,0}, -100)),
                    (2, (new int[] {-1,2,1,-4}, 1)),
                };
            }
        }
    }
}

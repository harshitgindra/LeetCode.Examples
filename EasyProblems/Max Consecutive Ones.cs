

namespace LeetCode.EasyProblems
{
    class Max_Consecutive_Ones
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int returnValue = 0;

            int index = 0;
            int tempCount = 0;
            while (index < nums.Length)
            {
                if (nums[index] == 1)
                {
                    tempCount++;
                }
                else
                {
                    returnValue = Math.Max(tempCount, returnValue);
                    tempCount = 0;
                }

                index++;
            }

            returnValue = Math.Max(tempCount, returnValue);
            return returnValue;
        }


        [Test(Description = "https://leetcode.com/problems/max-consecutive-ones/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Max Consecutive Ones")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindMaxConsecutiveOnes(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (3, [1, 1, 0, 1, 1, 1]),
            };
    }
}
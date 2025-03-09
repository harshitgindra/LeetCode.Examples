using NUnit.Framework.Legacy;

namespace LeetCode.Hard
{
    class First_Missing_Positive
    {
        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= Int32.MaxValue; i++)
                {
                    if (!nums.Contains(i))
                    {
                        return i;
                    }
                }
                return Int32.MaxValue;
            }
        }

        [Test(Description = "https://leetcode.com/problems/first-missing-positive/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("First Missing Positive")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FirstMissingPositive(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (1, new int[] { -5 }),
                    (1, new int[] { 2147483647 }),
                    (2, new int[] { 3,4,-1,1 }),
                    (3, new int[] {1,2,0}),
                    (1, new int[] { 7,8,9,11,12 })
                };
            }
        }
    }
}

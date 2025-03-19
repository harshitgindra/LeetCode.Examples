

namespace LeetCode.MediumProblems
{
    class Find_the_Duplicate_Number
    {
        public int FindDuplicateSol2(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    return nums[i];
                }
            }

            return nums[nums.Length - 1];
        }

        public int FindDuplicateSol1(int[] nums)
        {
            foreach (var item in nums)
            {
                var i = Math.Abs(item);
                if (nums[i] < 0)
                {
                    return i;
                }
                else
                {
                    nums[i] = nums[i] * -1;
                }
            }
            return 0;
        }

        [Test(Description = "https://leetcode.com/problems/find-the-duplicate-number/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Find the Duplicate Number")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindDuplicateSol1(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (2, new int[] {1,3,4,2,2}),
                    (3, new int[] {3,1,3,4,2}),
                    (1, new int[] {1,1}),
                };
            }
        }
    }
}

using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Remove_Duplicates_from_Sorted_Array_II
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length <= 2) return nums?.Length ?? 0;

            int k = 2;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[k - 2])
                {
                    nums[k++] = nums[i];
                }
            }
            return k;
        }

        [Test(Description = "https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Remove Duplicates from Sorted Array II")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = RemoveDuplicates(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (5, [1,1,1, 1,2,2,3]),
                (7, [0,0,1,1,1,1,2,3,3]),
                (5, [1,1,1,2,2,3]),
            };
    }
}

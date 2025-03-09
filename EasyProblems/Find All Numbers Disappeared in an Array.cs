using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Find_All_Numbers_Disappeared_in_an_Array
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var recs = Enumerable.Range(1, nums.Length).Except(nums)
                .ToList();

            return recs;
        }

        [Test(Description = "https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Find All Numbers Disappeared in an Array")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = FindDisappearedNumbers(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input =>
            new List<(int[] Output, int[] Input)>()
            {
                ([5,6], [4,3,2,7,8,2,3,1])
            };
    }
}

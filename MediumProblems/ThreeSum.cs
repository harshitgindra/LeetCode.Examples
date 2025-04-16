namespace LeetCode.MediumProblems
{
    public class ThreeSumSolution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> returnValue = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int threeSum = nums[i] + nums[left] + nums[right];

                    if (threeSum > 0)
                        right--;
                    else if (threeSum < 0)
                        left++;
                    else
                    {
                        List<int> currentList =
                        [
                            nums[i],
                            nums[left],
                            nums[right]
                        ];
                        returnValue.Add(currentList);
                        left++;
                        while (nums[left] == nums[left - 1] && left < right)
                            left++;
                    }
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/3sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("3Sum")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<IList<int>> Output, int[] Input) item)
        {
            var response = ThreeSum(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(IList<IList<int>> Output, int[] Input)> Input =>
            new List<(IList<IList<int>> Output, int[] Input)>()
            {
                (new List<IList<int>>()
                {
                    new List<int>() { -1, -1, 2 },
                    new List<int>() { -1, 0, 1 }
                }, [-1, 0, 1, 2, -1, -4]),
            };
    }
}
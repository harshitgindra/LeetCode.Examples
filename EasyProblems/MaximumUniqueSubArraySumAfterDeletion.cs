namespace LeetCode.EasyProblems;

public class MaximumUniqueSubArraySumAfterDeletion
{
    public int MaxSum(int[] nums)
    {
        Array.Sort(nums);
        int sum = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] != nums[i + 1])
            {
                if (sum < sum + nums[i])
                {
                    sum += nums[i];
                }
                else
                {
                    break;
                }
            }
        }

        return sum;
    }

    [Test(Description = "https://leetcode.com/problems/maximum-unique-subarray-sum-after-deletion/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Maximum Unique SubArray Sum After Deletion")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = MaxSum(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[] Input)> Input =>
        new List<(int Output, int[] Input)>()
        {
            (20, [20, -20]),
            (-100, [-100]),
            (3, [1, 2, -1, -2, 1, 0, -1]),
            (15, [1, 2, 3, 4, 5]),
        };
}
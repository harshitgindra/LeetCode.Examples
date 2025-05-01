namespace LeetCode.EasyProblems;

public class CountSubarraysOfLength3WithCondition
{
    public int CountSubarrays(int[] nums)
    {
        int count = 0;
        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i] % 2 == 0 && nums[i] / 2 == nums[i - 1] + nums[i + 1])
            {
                count++;
            }
        }

        return count;
    }

    [Test(Description = "https://leetcode.com/problems/count-subarrays-of-length-three-with-a-condition/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Count Subarrays Of Length 3 With A Condition")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = CountSubarrays(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[] Input)> Input =>
        new List<(int Output, int[] Input)>()
        {
            (1, [1, 2, 1, 4, 1]),
        };
}
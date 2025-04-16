namespace LeetCode.EasyProblems;

public class MinimumOperationsToMakeArraySumDivisibleByK
{
    public int MinOperations(int[] nums, int k)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }

        if (sum < k)
        {
            return sum;
        }

        return sum % k;
    }

    [Test(Description = "https://leetcode.com/problems/minimum-operations-to-make-array-sum-divisible-by-k/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Minimum operations to make array sum divisible by k")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, (int[] nums, int k) Input) item)
    {
        var response = MinOperations(item.Input.nums, item.Input.k);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, (int[] nums, int k) Input)> Input =>
        new List<(int, (int[] nums, int k))>()
        {
            (4, ([3, 9, 7], 5)),
            (5, ([3, 2], 6)),
        };
}
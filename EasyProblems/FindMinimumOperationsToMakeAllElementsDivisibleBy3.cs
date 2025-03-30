namespace LeetCode.EasyProblems;

public class FindMinimumOperationsToMakeAllElementsDivisibleBy3
{
    public int MinimumOperations(int[] nums)
    {
        int count = 0;

        foreach (var num in nums)
        {
            if (num != 0 && num % 3 != 0)
            {
                count++;
            }
        }
        return count;
    }
    
    [Test(Description = "https://leetcode.com/problems/find-minimum-operations-to-make-all-elements-divisible-by-three/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Find Minimum Operations To Make All Elements Divisible by 3")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = MinimumOperations(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[] Input)> Input =>
        new List<(int Output, int[] Input)>()
        {
            (3, [1,2,3,4]),
            (0, [3,6,9]),
        };
}
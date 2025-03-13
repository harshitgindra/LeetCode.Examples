namespace LeetCode.EasyProblems;

public class TwoSumSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> seen = new Dictionary<int, int>();
        int[] result = new int[2];
        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            if (seen.ContainsKey(diff))
            {
                result[0] = seen[diff];
                result[1] = i;
                return result;
            }
            else if (!seen.ContainsKey(nums[i]))
                seen.Add(nums[i], i);
        }

        return result;
    }

    [Test(Description = "https://leetcode.com/problems/two-sum/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Two Sum")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int[] Output, (int[] nums, int target) Input) item)
    {
        var response = TwoSum(item.Input.nums, item.Input.target);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int[] Output, (int[] nums, int target) Input)> Input =>
        new List<(int[] Output, (int[] nums, int target) Input)>()
        {
            ([0, 1], ([2, 7, 11, 15], 9)),
        };
}
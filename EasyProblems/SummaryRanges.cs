namespace LeetCode.EasyProblems;

public class SummaryRangesSolution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();

        // Handle empty array case
        if (nums == null || nums.Length == 0)
        {
            return result;
        }

        int start = nums[0]; // Track the start of current range

        for (int i = 0; i < nums.Length; i++)
        {
            // If next number is consecutive, continue to extend current range
            if (i < nums.Length - 1 && nums[i + 1] == nums[i] + 1)
            {
                continue;
            }

            // Current range is complete, add to result
            if (start == nums[i])
            {
                // Single number range
                result.Add(start.ToString());
            }
            else
            {
                // Multi-number range
                result.Add($"{start}->{nums[i]}");
            }

            // Start a new range if there are more elements
            if (i < nums.Length - 1)
            {
                start = nums[i + 1];
            }
        }

        return result;
    }

    [Test(Description = "https://leetcode.com/problems/summary-ranges/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Summary Ranges")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int[] Input, string[] Output) item)
    {
        var response = SummaryRanges(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int[] Input, string[] Output)> Input =>
        new List<(int[] Input, string[] Output)>()
        {
            (new int[] { 0, 1, 2, 4, 5, 7 }, new string[] { "0->2", "4->5", "7" }),
            (new int[] { 0, 2, 3, 4, 6, 8, 9 }, new string[] { "0", "2->4", "6", "8->9" }),
            (new int[] { }, new string[] { }),
            (new int[] { -1 }, new string[] { "-1" }),
            (new int[] { 0 }, new string[] { "0" }),
            (new int[] { -5, -4, -3, -1, 0, 1, 3, 4, 5, 7, 8 }, new string[] { "-5->-3", "-1->1", "3->5", "7->8" }),
            (new int[] { 1, 3, 5, 7 }, new string[] { "1", "3", "5", "7" }),
            (new int[] { 1, 2, 3, 4, 5 }, new string[] { "1->5" }),
            (new int[] { -3, -2, -1 }, new string[] { "-3->-1" }),
            (new int[] { -1, 0, 1, 2, 4, 5, 7 }, new string[] { "-1->2", "4->5", "7" })
        };
}
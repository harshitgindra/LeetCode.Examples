namespace LeetCode.EasyProblems;

public class MinimumAverageOfSmallestAndLargestElements
{
    public double MinimumAverage(int[] nums)
    {
        // Sort the list to easily access smallest and largest elements
        Array.Sort(nums);

        double minAverage = double.MaxValue;
        int left = 0;
        int right = nums.Count() - 1;

        // Process pairs until all elements are used
        while (left < right)
        {
            // Calculate average of current smallest and largest elements
            double currentAverage = (nums[left] + nums[right]) / 2.0;

            // Update minimum average if current one is smaller
            minAverage = Math.Min(minAverage, currentAverage);

            // Move to the next pair
            left++;
            right--;
        }

        return minAverage;
    }

    [Test(Description = "https://leetcode.com/problems/minimum-average-of-smallest-and-largest-elements/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Find Minimum Operations To Make All Elements Divisible by 3")]
    [TestCaseSource(nameof(Input))]
    public void Test1((double Output, int[] Input) item)
    {
        var response = MinimumAverage(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(double Output, int[] Input)> Input =>
        new List<(double Output, int[] Input)>()
        {
            (5.5, [7, 8, 3, 4, 15, 13, 4, 1]),
        };
}
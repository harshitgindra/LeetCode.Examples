namespace LeetCode.MediumProblems;

public class FindPeakElementSolution
{
    public int FindPeakElement(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;

        // Binary search for a peak
        while (left < right) {
            int mid = left + (right - left) / 2;

            // If the current mid is greater than its right neighbor,
            // then the peak must be on the left side (including mid)
            if (nums[mid] > nums[mid + 1]) {
                right = mid;
            } else {
                // Otherwise, the peak is on the right side (excluding mid)
                left = mid + 1;
            }
        }

        // When left == right, we've found a peak
        return left;
    }
    
    [Test(Description = "https://leetcode.com/problems/find-peak-element/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Find Peak Element")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = FindPeakElement(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[] Input)> Input =>
        new List<(int Output, int[] Input)>()
        {
            (5, [1,2,1,3,5,6,4]),
        };
}
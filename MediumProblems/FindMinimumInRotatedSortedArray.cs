namespace LeetCode.MediumProblems;

public class FindMinimumInRotatedSortedArray
{
    public int FindMin(int[] nums) {
        // If the array is not rotated (already sorted), return the first element
        if (nums[0] <= nums[nums.Length - 1]) {
            return nums[0];
        }

        int left = 0, right = nums.Length - 1;

        // Binary search for the minimum element
        while (left < right) {
            int mid = left + (right - left) / 2;

            if (nums[mid] > nums[right]) {
                // Minimum must be in the right half (excluding mid)
                left = mid + 1;
            } else {
                // Minimum is in the left half (including mid)
                right = mid;
            }
        }

        // When left == right, we've found the minimum
        return nums[left];
    }
    
    [Test(Description = "https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Find Minimum In Rotated Sorted Array")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = FindMin(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[] Input)> Input =>
        new List<(int Output, int[] Input)>()
        {
            (0, [4,5,6,7,0,1,2]),
        };
}
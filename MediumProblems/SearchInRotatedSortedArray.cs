namespace LeetCode.MediumProblems;

public class SearchInRotatedSortedArray
{
    public int Search(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;  // Prevent integer overflow
            
            // Target found at mid index
            if (nums[mid] == target) {
                return mid;
            }

            // Case 1: Left half [left..mid] is sorted
            if (nums[left] <= nums[mid]) {
                // If target is in sorted left half's range
                if (nums[left] <= target && target < nums[mid]) {
                    right = mid - 1;  // Search left half
                } else {
                    left = mid + 1;   // Search right half
                }
            }
            // Case 2: Right half [mid..right] is sorted
            else {
                // If target is in sorted right half's range
                if (nums[mid] < target && target <= nums[right]) {
                    left = mid + 1;   // Search right half
                } else {
                    right = mid - 1;  // Search left half
                }
            }
        }
        
        // Target not found in array
        return -1;
    }
    
    [Test(Description = "https://leetcode.com/problems/search-in-rotated-sorted-array/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Search In Rotated Sorted Array")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, (int[], int) Input) item)
    {
        var response = Search(item.Input.Item1, item.Input.Item2);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, (int[], int) Input)> Input =>
        new List<(int Output, (int[], int) Input)>()
        {
            (1, ([4,5,6,7,0,1,2], 0)),
        };
}
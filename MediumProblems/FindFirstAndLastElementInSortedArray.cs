namespace LeetCode.MediumProblems;

public class FindFirstAndLastElementInSortedArray
{
    public int[] SearchRange(int[] nums, int target) {
        return new int[] {
            FindPosition(nums, target, true),  // Find first occurrence
            FindPosition(nums, target, false)  // Find last occurrence
        };
    }
    private int FindPosition(int[] nums, int target, bool isFirst) {
        int result = -1;
        int left = 0, right = nums.Length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            
            if (nums[mid] == target) {
                result = mid;  // Update potential result
                
                // Search left for first occurrence, right for last
                if (isFirst) right = mid - 1;
                else left = mid + 1;
            }
            else if (nums[mid] < target) {
                left = mid + 1;  // Target in right half
            }
            else {
                right = mid - 1;  // Target in left half
            }
        }
        
        return result;
    }
    
    [Test(Description = "https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Find First and Last Position Of Element In Sorted Array")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int[] Output, (int[] nums, int target) Input) item)
    {
        var response = SearchRange(item.Input.nums, item.Input.target);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int[] Output, (int[] nums, int target) Input)> Input =>
        new List<(int[] Output, (int[] nums, int target) Input)>()
        {
            ([3,4], ([5,7,7,8,8,10], 8)),
        };
}
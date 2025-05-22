namespace LeetCode.HardProblems;

public class MedianOfTwoSortedArrays
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // Ensure nums1 is the smaller array to optimize binary search steps
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);

        int x = nums1.Length; // Smaller array
        int y = nums2.Length; // Larger array
        int low = 0, high = x; // Binary search boundaries for partitionX

        while (low <= high)
        {
            // Partition point in nums1 (smaller array)
            int partitionX = (low + high) / 2;
            // Partition point in nums2 (derived to balance left/right elements)
            int partitionY = (x + y + 1) / 2 - partitionX;

            // Handle edge cases for partition boundaries
            int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
            int minRightX = (partitionX == x) ? int.MaxValue : nums1[partitionX];
            int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
            int minRightY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

            // Check if partitions are correct
            if (maxLeftX <= minRightY && maxLeftY <= minRightX)
            {
                // Even total length: average of two middle values
                if ((x + y) % 2 == 0)
                    return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                // Odd total length: middle value
                else
                    return Math.Max(maxLeftX, maxLeftY);
            }
            // Adjust binary search boundaries
            else if (maxLeftX > minRightY)
            {
                // Move partitionX left
                high = partitionX - 1;
            }
            else
            {
                // Move partitionX right
                low = partitionX + 1;
            }
        }

        throw new ArgumentException("Input arrays are not sorted");
    }

    [Test(Description = "https://leetcode.com/problems/median-of-two-sorted-arrays/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Median of two sorted arrays")]
    [TestCaseSource(nameof(Input))]
    public void Test1((double Output, (int[] nums1, int[] nums2) Input) item)
    {
        var response = FindMedianSortedArrays(item.Input.nums1, item.Input.nums2);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(double Output, (int[] nums1, int[] nums2) Input)> Input
    {
        get
        {
            return new List<(double Output, (int[] nums1, int[] nums2) Input)>
            {
                (2.5, ([1, 2], [3, 4])),
                (2.0, ([1, 2], [3])),
            };
        }
    }
}
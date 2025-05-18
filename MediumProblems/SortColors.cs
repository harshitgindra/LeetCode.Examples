namespace LeetCode.MediumProblems;

public class SortColorsSolution
{
    public void SortColors(int[] nums)
    {
        // Counters for each color (0, 1, 2)
        int zero = 0, one = 0, two = 0;

        // Count the occurrences of 0s, 1s, and 2s
        foreach (int n in nums)
        {
            if (n == 0) zero++;
            else if (n == 1) one++;
            else two++;
        }

        // Overwrite the array with the correct number of 0s, then 1s, then 2s
        int index = 0;
        // Fill with 0s
        for (int i = 0; i < zero; i++) nums[index++] = 0;
        // Fill with 1s
        for (int i = 0; i < one; i++) nums[index++] = 1;
        // Fill with 2s
        for (int i = 0; i < two; i++) nums[index++] = 2;
    }

    [Test(Description = "https://leetcode.com/problems/sort-colors/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Sort Colors")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int[] Output, int[] Input) item)
    {
        SortColors(item.Input);
        Assert.That(item.Output, Is.EqualTo(item.Input));
    }

    public static IEnumerable<(int[] Output, int[] Input)> Input =>
        new List<(int[] Output, int[] Input)>()
        {
            ([0, 0, 1, 1, 2, 2], [2, 0, 2, 1, 1, 0]),
        };
}
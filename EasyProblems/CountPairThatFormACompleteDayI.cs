namespace LeetCode.EasyProblems;

public class CountPairThatFormACompleteDayI
{
    public int CountCompleteDayPairs(int[] hours)
    {
        // Dictionary to store the count of each remainder when dividing by 24
        Dictionary<int, int> remainderCount = new Dictionary<int, int>();

        // Counter for valid pairs
        int count = 0;

        // Iterate through each hour in the input array
        foreach (int hour in hours)
        {
            // Calculate the remainder when dividing by 24
            int remainder = hour % 24;

            // Check if this hour can form a complete day with any previously seen hours
            if (remainder == 0)
            {
                // If remainder is 0, it forms a pair with other 0 remainders
                // (e.g., 24 + 24 = 48, which is 2 complete days)
                if (remainderCount.ContainsKey(0))
                {
                    count += remainderCount[0];
                }
            }
            else
            {
                // For non-zero remainders, we need to find the complementary remainder
                // (e.g., if remainder is 5, we need to find hours with remainder 19)
                int complementaryRemainder = 24 - remainder;

                if (remainderCount.ContainsKey(complementaryRemainder))
                {
                    count += remainderCount[complementaryRemainder];
                }
            }

            // Add the current remainder to our dictionary
            if (remainderCount.ContainsKey(remainder))
            {
                remainderCount[remainder]++;
            }
            else
            {
                remainderCount[remainder] = 1;
            }
        }

        return count;
    }

    [Test(Description = "https://leetcode.com/problems/count-pairs-that-form-a-complete-day-i/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Count Pairs That Form A Complete Day I")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = CountCompleteDayPairs(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[] Input)> Input =>
        new List<(int Output, int[] Input)>()
        {
            (2, [11, 22, 2, 25, 19, 2]),
            (2, [12, 12, 30, 24, 24]),
        };
}
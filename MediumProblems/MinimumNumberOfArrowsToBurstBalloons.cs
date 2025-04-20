namespace LeetCode.MediumProblems;

public class MinimumNumberOfArrowsToBurstBalloons
{
    public int FindMinArrowShots(int[][] points)
    {
        // Sort the balloons based on their end coordinates
        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));

        int arrows = 1;
        int prevEnd = points[0][1];

        // Count the number of non-overlapping intervals
        for (int i = 1; i < points.Length; ++i)
        {
            if (points[i][0] > prevEnd)
            {
                arrows++;
                prevEnd = points[i][1];
            }
        }

        return arrows;
    }

    [Test(Description = "https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/")]
    [Category("Hard")]
    [Category("LeetCode")]
    [Category("Minimum number of arrows to Burst Balloons")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[][] Input) item)
    {
        var response = FindMinArrowShots(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[][] Points)> Input =>
        new List<(int Output, int[][] Points)>()
        {
            (
                4,
                new int[][]
                {
                    new int[] { 1, 2 },
                    new int[] { 3, 4 },
                    new int[] { 5, 6 },
                    new int[] { 7, 8 }
                }
            ),
            (
                1,
                new int[][]
                {
                    new int[] { 1, 2 }
                }
            ),
            (
                1,
                new int[][]
                {
                    new int[] { 1, 2 },
                    new int[] { 1, 2 },
                    new int[] { 1, 2 }
                }
            ),
            (
                2,
                new int[][]
                {
                    new int[] { -2147483646, -2147483645 },
                    new int[] { 2147483646, 2147483647 }
                }
            ),
            (
                2,
                new int[][]
                {
                    new int[] { 1, 2 },
                    new int[] { 2, 3 },
                    new int[] { 3, 4 }
                }
            ),
        };
}
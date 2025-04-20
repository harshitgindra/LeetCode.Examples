namespace LeetCode.MediumProblems;

public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> result = new List<int[]>();

        // Case 1: Add all intervals that come before newInterval (no overlap)
        int i = 0;
        while (i < intervals.Length && intervals[i][1] < newInterval[0])
        {
            result.Add(intervals[i++]);
        }

        // Case 2: Merge overlapping intervals with newInterval
        while (i < intervals.Length && intervals[i][0] <= newInterval[1])
        {
            // Expand newInterval to include the current overlapping interval
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }

        // Add the merged interval
        result.Add(newInterval);

        // Case 3: Add all intervals that come after newInterval (no overlap)
        while (i < intervals.Length)
        {
            result.Add(intervals[i++]);
        }

        return result.ToArray();
    }

    [Test(Description = "https://leetcode.com/problems/insert-interval/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Insert Interval")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int[][] Output, int[][] Intervals, int[] NewInterval) item)
    {
        var response = Insert(item.Intervals, item.NewInterval);
        // Compare the 2D arrays
        Assert.That(response.Length, Is.EqualTo(item.Output.Length));
        for (int i = 0; i < response.Length; i++)
        {
            Assert.That(response[i], Is.EqualTo(item.Output[i]));
        }
    }

    public static IEnumerable<(int[][] Output, int[][] Intervals, int[] NewInterval)> Input =>
        new List<(int[][] Output, int[][] Intervals, int[] NewInterval)>()
        {
            (
                new int[][] { new int[] { 1, 5 }, new int[] { 6, 9 } },
                new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } },
                new int[] { 2, 5 }
            ),
            (
                new int[][] { new int[] { 1, 2 }, new int[] { 3, 10 }, new int[] { 12, 16 } },
                new int[][]
                {
                    new int[] { 1, 2 }, new int[] { 3, 5 }, new int[] { 6, 7 }, new int[] { 8, 10 },
                    new int[] { 12, 16 }
                },
                new int[] { 4, 8 }
            ),
            (
                new int[][] { new int[] { 1, 5 } },
                new int[][] { },
                new int[] { 1, 5 }
            ),
            (
                new int[][] { new int[] { 1, 7 } },
                new int[][] { new int[] { 1, 5 } },
                new int[] { 2, 7 }
            ),
            (
                new int[][] { new int[] { 0, 1 }, new int[] { 2, 5 } },
                new int[][] { new int[] { 2, 5 } },
                new int[] { 0, 1 }
            ),
            (
                new int[][] { new int[] { 0, 9 } },
                new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } },
                new int[] { 0, 6 }
            )
        };
}
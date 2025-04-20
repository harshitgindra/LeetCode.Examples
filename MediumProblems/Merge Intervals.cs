namespace LeetCode.MediumProblems
{
    class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            // Handle edge case
            if (intervals == null || intervals.Length <= 1)
            {
                return intervals;
            }

            // Sort intervals by start time to easily find overlaps
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> mergedList = new List<int[]>();
            int[] currentInterval = intervals[0];

            // Iterate through all intervals
            foreach (var interval in intervals)
            {
                // If current interval overlaps with the next one, merge them
                if (currentInterval[1] >= interval[0])
                {
                    // Update end time to the maximum of both intervals
                    currentInterval[1] = Math.Max(currentInterval[1], interval[1]);
                }
                else
                {
                    // No overlap, add current interval to result and move to next one
                    mergedList.Add(currentInterval);
                    currentInterval = interval;
                }
            }

            // Add the last interval
            mergedList.Add(currentInterval);

            return mergedList.ToArray();
        }

        [Test(Description = "https://leetcode.com/problems/merge-intervals/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Merge Intervals")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[][] Output, int[][] Input) item)
        {
            var response = Merge(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[][] Output, int[][])> Input
        {
            get
            {
                return new List<(int[][] Output, int[][])>()
                {
                    (new int[][]
                        {
                            [1, 6],
                            [8, 10],
                            [15, 18],
                        }
                        , new int[][]
                        {
                            [1, 3],
                            [2, 6],
                            [8, 10],
                            [15, 18],
                        }),
                };
            }
        }
    }
}
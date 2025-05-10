namespace LeetCode.MediumProblems
{
    internal class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>(nums);
            int maxSequenceLength = 0;

            foreach (int num in numSet)
            {
                // Check if current number is the start of a sequence
                if (!numSet.Contains(num - 1))
                {
                    int currentLength = 1;

                    // Extend the sequence forward
                    while (numSet.Contains(num + currentLength))
                    {
                        currentLength++;
                    }

                    maxSequenceLength = Math.Max(maxSequenceLength, currentLength);
                }
            }

            return maxSequenceLength;
        }


        [Test(Description = "https://leetcode.com/problems/longest-consecutive-sequence/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Longest Consecutive Sequence")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = LongestConsecutive(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (4, [100, 4, 200, 1, 3, 2]),
                (2, [0, -1]),
            };
    }
}
namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/majority-element/
    /// </summary>
    class MajorityElementSolution
    {
        /// <summary>
        /// Finds the majority element in an array using the Boyer-Moore Majority Vote algorithm.
        /// </summary>
        /// <param name="nums">The input array.</param>
        /// <returns>The majority element.</returns>
        public int MajorityElement(int[] nums)
        {
            // Initialize the count and candidate variables.
            int count = 0;
            int candidate = 0;

            // Iterate through each number in the array.
            foreach (int num in nums)
            {
                // If the count is zero, set the current number as the candidate.
                if (count == 0)
                {
                    candidate = num;
                }

                // Increment the count if the current number matches the candidate, otherwise decrement.
                if (num == candidate)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            // Return the candidate as the majority element.
            return candidate;
        }
        
        [Test(Description = "https://leetcode.com/problems/majority-element/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Majority Element")]
        [TestCaseSource(nameof(Input))]
        public void TestMajorityElement((int Output, int[] Input) item)
        {
            var response = MajorityElement(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (3, [3,2,3]),
                (2, [2,2,1,1,1,2,2]),
                (5, [5,5,5,5,5,5,5,5,1,2,3,4]),
                (1, [1]),
            };
    }
}
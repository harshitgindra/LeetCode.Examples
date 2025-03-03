namespace LeetCode.May
{
    /// <summary>
    /// https://leetcode.com/problems/majority-element/
    /// </summary>
    class MajorityElementTest
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

    }
}
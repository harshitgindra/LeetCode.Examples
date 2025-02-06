namespace LeetCode.MediumProblems
{
    class Shuffle_an_Array
    {
        public class Solution
        {
            private int[] _data;
            public Solution(int[] nums)
            {
                _data = nums;
            }

            /** Resets the array to its original configuration and return it. */
            public int[] Reset()
            {
                return _data;
            }

            /** Returns a random shuffling of the array. */
            public int[] Shuffle()
            {
                return _data.OrderBy(x => Guid.NewGuid()).ToArray();
            }
        }
    }
}

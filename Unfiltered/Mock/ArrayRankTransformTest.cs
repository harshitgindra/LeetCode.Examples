namespace LeetCode.Mock
{
    /// <summary>
    /// https://leetcode.com/problems/rank-transform-of-an-array/
    /// </summary>
    class ArrayRankTransformTest
    {
        public int[] ArrayRankTransform(int[] arr)
        {
            int index = 1;
            var unique = arr.Distinct().OrderBy(x => x).ToDictionary(x => x, y => index++);

            int[] ret = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                ret[i] = unique[arr[i]];
            }
            return ret;
        }
    }
}

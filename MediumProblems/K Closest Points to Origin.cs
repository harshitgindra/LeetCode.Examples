namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/k-closest-points-to-origin/
    /// </summary>
    class K_Closest_Points_to_Origin
    {
        public int[][] KClosest(int[][] points, int K)
        {
            var dict = new SortedDictionary<int, List<int[]>>();
            for (int i = 0; i < points.Length; i++)
            {
                var item = points[i];
                var dist = item[0] * item[0] + item[1] * item[1];
                if (dict.ContainsKey(dist))
                {
                    dict[dist].Add(item);
                }
                else
                {
                    dict.Add(dist, new List<int[]>() { item });
                }
            }
            return dict.SelectMany(x => x.Value).Take(K).ToArray();
        }
    }
}

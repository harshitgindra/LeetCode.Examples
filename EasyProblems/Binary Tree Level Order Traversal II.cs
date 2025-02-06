using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems
{
    /// <summary>
    /// TODO
    /// </summary>
    class Binary_Tree_Level_Order_Traversal_II
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IDictionary<int, IList<int>> result = new Dictionary<int, IList<int>>();
            Read(root, 0, result);

            for (int i = 1; i < result.Count; i = i + 2)
            {
                result[i].Reverse();
            }

            return result.Values.ToList();
        }

        private void Read(TreeNode node, int level, IDictionary<int, IList<int>> result)
        {
            if (node != null)
            {
                Read(node.left, level + 1, result);
                Read(node.right, level + 1, result);

                if (result.ContainsKey(level))
                {
                    result[level].Add(node.val);
                }
                else
                {
                    result.Add(level, new List<int>() { node.val });
                }
            }
        }
    }
}

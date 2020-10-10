using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Binary_Tree_Zigzag_Level_Order_Traversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = Fetch(root, 0, new Dictionary<int, IList<int>>());
            foreach (var item in result)
            {
                if (item.Key % 2 != 0)
                {
                    item.Value.Reverse();
                }
            }
            return result.Values.ToList();
        }

        private IDictionary<int, IList<int>> Fetch(TreeNode node, int level, IDictionary<int, IList<int>> result)
        {
            if (node != null)
            {
                if (!result.ContainsKey(level))
                {
                    result.Add(level, new List<int>());
                }
                result[level].Add(node.val);

                result = Fetch(node.left, level + 1, result);
                result = Fetch(node.right, level + 1, result);
            }
            return result;
        }
    }
}

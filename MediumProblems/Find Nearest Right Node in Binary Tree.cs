using LeetCode.SharedUtils;

namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/find-nearest-right-node-in-binary-tree/
    /// </summary>
    public class Find_Nearest_Right_Node_in_Binary_Tree
    {
        public TreeNode FindNearestRightNode(TreeNode root, TreeNode u)
        {
            var result = Read(root, u, 1, new Dictionary<int, List<TreeNode>>());

            TreeNode returnValue = default;

            foreach (var item in result)
            {
                if (item.Value.Any(x => x.val == u.val))
                {
                    for (int i = 1; i < item.Value.Count; i++)
                    {
                        if (item.Value[i - 1].val == u.val)
                        {
                            returnValue = item.Value[i];
                        }
                    }
                }
            }

            return returnValue;
        }

        private Dictionary<int, List<TreeNode>> Read(TreeNode node, TreeNode u, int level,
            Dictionary<int, List<TreeNode>> result)
        {
            if (node != null)
            {
                if (result.ContainsKey(level))
                {
                    result[level].Add(node);
                }
                else
                {
                    result.Add(level, new List<TreeNode>() {node});
                }

                result = Read(node.left, u, level + 1, result);
                result = Read(node.right, u, level + 1, result);
            }

            return result;
        }
    }
}
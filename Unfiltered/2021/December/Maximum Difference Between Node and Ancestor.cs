using LeetCode.SharedUtils;

namespace LeetCode.Problems._2021.December
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/
    /// </summary>
    public class Maximum_Difference_Between_Node_and_Ancestor
    {
        private int _result = 0;
        public int MaxAncestorDiff(TreeNode root)
        {
            Helper(root, root.val, root.val);
            return _result;
        }

        private void Helper(TreeNode node, int max, int min)
        {
            if (node != null)
            {
                max = Math.Max(max, node.val);
                min = Math.Min(min, node.val);
               
                Helper(node.left, max, min);
                Helper(node.right, max, min);
            }
            else
            {
                _result = Math.Max(_result, Math.Abs(max - min)); 
            }
        }
    }
}
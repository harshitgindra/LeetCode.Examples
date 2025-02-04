using System;

namespace LeetCode.Easy
{
    public class Diameter_of_Binary_Tree
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root != null && root.left != null && root.right != null)
            {
                return Traverse(root, 0);
            }

            return 0;
        }

        private int Traverse(TreeNode node, int depth)
        {
            if (node != null)
            {
                depth = Math.Max(Math.Max(Traverse(node.left, depth + 1), Traverse(node.right, depth + 1)), depth);
            }

            return depth;
        }
    }
}
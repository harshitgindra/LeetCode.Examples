using LeetCode.SharedUtils;

namespace LeetCode.May
{
    public class CousinsInBinaryTree
    {
        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (root.val == x || root.val == y)
            {
                return false;
            }

            bool a = IsLeft(root, x);
            bool b = IsLeft(root, y);
            return a == b;
        }

        private bool IsLeft(TreeNode node, int value)
        {
            if (node.left != null)
            {
                if (node.left.val == value)
                {
                    return true;
                }

                if (IsLeft(node.left, value))
                {
                    return true;
                }
            }

            if (node.right != null)
            {
                if (IsLeft(node.right, value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

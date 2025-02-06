using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems
{
    class Trim_a_Binary_Search_Tree
    {
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root != null)
            {
                if (root.val > high || root.val < low)
                {
                    if (root.left != null && root.left?.val > high || root.left?.val < low)
                    {
                        root = root.left;
                    }
                    else
                    {
                        root = root.right;
                    }
                    root = TrimBST(root, low, high);
                }
                else
                {
                    root.left = TrimBST(root.left, low, high);
                    root.right = TrimBST(root.right, low, high);
                }
            }
            return root;
        }
    }
}

using LeetCode.SharedUtils;

namespace Easy;

/// <summary>
/// https://leetcode.com/problems/balanced-binary-tree/
/// </summary>
public class BalancedBinaryTree
{
    public bool IsBalanced(TreeNode root)
    {
        int returnValue = _Dfs(root);
        return returnValue != -1;
    }

    private int _Dfs(TreeNode node)
    {
        if (node != null)
        {
            int left = _Dfs(node.left);
            if (left == -1)
            {
                return -1;
            }

            int right = _Dfs(node.right);

            if (right == -1)
            {
                return -1;
            }

            int diff = left - right;
            if (diff != 0 && diff != 1 && diff != -1)
            {
                return -1;
            }

            return Math.Max(left, right) + 1;
        }

        return 0;
    }
}

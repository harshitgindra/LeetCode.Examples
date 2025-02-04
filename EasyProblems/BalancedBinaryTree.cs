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

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
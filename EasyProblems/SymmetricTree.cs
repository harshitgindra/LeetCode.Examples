using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems;

/// <summary>
/// https://leetcode.com/problems/symmetric-tree/
/// </summary>
public class SymmetricTree
{
    public bool IsSymmetric(TreeNode root) {
        if (root == null)
        {
            return true;
        }

        return _Traverse(root.left, root.right);
    }

    private bool _Traverse(TreeNode left, TreeNode right)
    {
        if (left == null && right == null)
        {
            return true;
        }

        if (left?.val != right?.val)
        {
            return false;
        }
        
        return (_Traverse(left?.left, right?.right) && _Traverse(left?.right, right?.left));
    }
}
using Easy;
using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems;

public class SameTree
{
    public bool IsSameTree(TreeNode p, TreeNode q) {

        if (p == null && q == null)
        {
            return true;
        }

        if (q == null && p != null || q != null && p == null)
        {
            return false;
        }

        if (p.val != q.val)
        {
            return false;
        }

        if (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right))
        {
            return true;
        }

        return false;
    }
}
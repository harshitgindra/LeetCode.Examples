using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/subtree-of-another-tree/
    /// </summary>
    class Subtree_of_Another_Tree
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;

            if (s == null || t == null) return false;

            return Traverse(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        public bool Traverse(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;

            if (s == null || t == null) return false;

            return s.val == t.val && Traverse(s.left, t.left) && Traverse(s.right, t.right);
        }
    }
}

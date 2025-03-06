using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems;

/// <summary>
/// LeetCode 222
/// https://leetcode.com/problems/count-complete-tree-nodes/
/// </summary>
public class CountCompleteTreeNode
{
    public int CountNodes(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        else
        {
            return CountNodes(root.left) + CountNodes(root.right) + 1;
        }
    }
}
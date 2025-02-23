using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems;

/// <summary>
/// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
/// </summary>
public class ConvertSortedArrayToBinarySearchTree
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
    public TreeNode SortedArrayToBST(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return null;

        return BuildTree(nums, 0, nums.Length - 1);
    }

    private TreeNode BuildTree(int[] nums, int i, int j)
    {
        if (j < i)
            return null;

        int mid = j + (i - j) / 2;
        TreeNode node = new TreeNode(nums[mid]);

        node.left = BuildTree(nums, i, mid - 1);
        node.right = BuildTree(nums, mid + 1, j);

        return node;
    }
}
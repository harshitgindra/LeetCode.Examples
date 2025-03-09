using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems;

/// <summary>
/// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
/// </summary>
public class ConvertSortedArrayToBinarySearchTree
{
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
    
    [Test(Description = "https://leetcode.com/problems/count-complete-tree-nodes/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Count Complete Tree Nodes")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int?[] Output, int[] Input) item)
    {
        var response = SortedArrayToBST(item.Input);
        Assert.That(response.ToArray(), Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int?[] Output, int[] Input)> Input =>
        new List<(int?[] Output, int[] Input)>()
        {
            ([0,-3,9,-10,null,5], ([-10,-3,0,5,9])),
        };
}
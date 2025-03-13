namespace LeetCode.EasyProblems;

public class MinimumAbsoluteDifferenceInBst
{
    public int GetMinimumDifference(TreeNode root) {
        return InorderTraversal(root, int.MaxValue, null).minDiff;
    }
    
    private (int minDiff, TreeNode prev) InorderTraversal(TreeNode root, int minDiff, TreeNode prev) {
        if (root == null) {
            return (minDiff, prev);
        }
        
        (minDiff, prev) = InorderTraversal(root.left, minDiff, prev);
        
        if (prev != null) {
            minDiff = Math.Min(minDiff, root.val - prev.val);
        }
        prev = root;
        
        return InorderTraversal(root.right, minDiff, prev);
    }

    [Test(Description = "https://leetcode.com/problems/minimum-absolute-difference-in-bst/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Minimum absolute difference in BST")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int?[] Input) item)
    {
        var response = GetMinimumDifference(item.Input.ToTreeNode());
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<( int Output, int?[] Input)> Input =>
        new List<(int Output, int?[] Input)>()
        {
            (9, [236, 104, 701, null, 227, null, 911]),
            (1, [4, 2, 6, 1, 3]),
            (1, [1, 0, 48, null, null, 12, 49]),
        };
}
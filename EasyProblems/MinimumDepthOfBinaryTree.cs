using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems;

public class MinimumDepthOfBinaryTree
{
    private int _minHeight = Int32.MaxValue;

    public int MinDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        _Dfs(root, 0);
        return _minHeight;
    }

    private void _Dfs(TreeNode root, int height)
    {
        if (root != null && height < _minHeight)
        {
            if (root.left == null && root.right == null)
            {
                _minHeight = Math.Min(_minHeight, height + 1);
            }
            else
            {
                _Dfs(root.left, height + 1);
                _Dfs(root.right, height + 1);
            }
        }
    }

    [Test(Description = "https://leetcode.com/problems/minimum-depth-of-binary-tree/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Minimum Depth Of Binary Tree")]
    [TestCaseSource("Input")]
    
    public void Test1((int Output, int?[] Input) item)
    {
        var treeNode = TreeNodeBuilder.ArrayToTreeNode(item.Input);
        var response = MinDepth(treeNode);
        ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(int Output, int?[] Input)> Input
    {
        get
        {
            return new List<(int Output, int?[] Input)>()
            {
                // (2, new int?[]{3,9,20,null,null,15,7}),
                (5, new int?[] { 2, null, 3, null, 4, null, 5, null, 6 }),
            };
        }
    }
}
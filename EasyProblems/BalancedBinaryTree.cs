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
        if (node == null)
        {
            return 0;
        }
        
        int leftHeight = _Dfs(node.left);
        if (leftHeight == -1)
        {
            return -1;
        }
        int rightHeight = _Dfs(node.right);
        if (rightHeight == -1)
        {
            return -1;
        }
        
        int diff = Math.Abs(leftHeight - rightHeight);
        if (diff < 2)
        {
            return Math.Max(leftHeight, rightHeight) + 1;
        }
        else
        {
            return -1;
        }
    }
    
    [Test(Description = "https://leetcode.com/problems/balanced-binary-tree/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Balanced Binary Tree")]
    [TestCaseSource(nameof(Input))]
    public void Test1((bool Output, int?[] Input) item)
    {
        var treeNode = TreeNodeBuilder.ArrayToTreeNode(item.Input);
        var response = IsBalanced(treeNode);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(bool Output, int?[] Input)> Input
    {
        get
        {
            return new List<(bool Output, int?[] Input)>()
            {
                // (true, new int?[]{3,9,20,null,null,15,7}),
                (false, new int?[]{1,2,2,3,3,null,null,4,4}),
            };
        }
    }

}

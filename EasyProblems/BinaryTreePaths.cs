namespace LeetCode.EasyProblems;

public class BinaryTreePathsSolution
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        IList<string> result = new List<string>();
        _dfs(root, "", result);
        return result;
    }

    private void _dfs(TreeNode node, string path, IList<string> result)
    {
        string tmpPath = $"{path}->{node?.val}";
        if (path == string.Empty)
        {
            tmpPath = $"{node?.val}";
        }

        if (node == null)
        {
            return;
        }

        if (node.left == null && node.right == null)
        {
            result.Add(tmpPath);
            return;
        }

        if (node.left != null)
        {
            _dfs(node.left, tmpPath, result);
        }

        if (node.right != null)
        {
            _dfs(node.right, tmpPath, result);
        }
    }

    [Test(Description = "https://leetcode.com/problems/binary-tree-paths/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Binary Tree Paths")]
    [TestCaseSource(nameof(Input))]
    public void Test1((IList<string> Output, int?[] Input) item)
    {
        var response = BinaryTreePaths(item.Input.ToTreeNode());
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<( IList<string> Output, int?[] Input)> Input =>
        new List<(IList<string> Output, int?[] Input)>()
        {
            (["1->2->5", "1->3"], [1, 2, 3, null, 5]),
        };
}
namespace LeetCode.MediumProblems;

public class BinaryTreeRightSideView
{
    public IList<int> RightSideView(TreeNode root) {
        var dict = new Dictionary<int, int>();
        _Helper(root, 1, dict);
        return dict.Values.ToList();
    }

    private void _Helper(TreeNode node, int depth, Dictionary<int, int> result )
    {
        if (node != null)
        {
            result[depth] = node.val;
            _Helper(node.left, depth + 1, result );
            _Helper(node.right, depth + 1, result );
        }
    }
    
    [Test(Description = "https://leetcode.com/problems/binary-tree-right-side-view/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Binary Tree Right Side View")]
    [TestCaseSource(nameof(Input))]
    public void Test1((List<int> Output, int?[] Input) item)
    {
        var response = RightSideView(item.Input.ToTreeNode());
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(List<int> Output, int?[] Input)> Input =>
        new List<(List<int> Output, int?[] Input)>()
        {
            ([1,3,4], [1,2,3,null,5,null,4]),
            ([1,3,4, 5], [1,2,3,4,null,null,null,5]),
        };
}
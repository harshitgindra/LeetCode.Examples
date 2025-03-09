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
    
    [Test(Description = "https://leetcode.com/problems/count-complete-tree-nodes/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Count Complete Tree Nodes")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int?[] Input) item)
    {
        var response = CountNodes(item.Input.ToTreeNode());
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int?[] Input)> Input =>
        new List<(int Output, int?[] Input)>()
        {
            (6, ([1,2,3,4,5,6])),
        };
}
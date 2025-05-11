namespace LeetCode.MediumProblems;

public class SumRootToLeafNumbers
{
    public int SumNumbers(TreeNode root)
    {
        return DfsTraversal(root, currentSum: 0);
    }

    private int DfsTraversal(TreeNode node, int currentSum)
    {
        if (node == null) return 0;

        // Update current path value
        currentSum = currentSum * 10 + node.val;

        // Leaf node - return complete path sum
        if (node.left == null && node.right == null)
            return currentSum;

        // Recursively process children and sum their results
        return DfsTraversal(node.left, currentSum) + DfsTraversal(node.right, currentSum);
    }

    [Test(Description = "https://leetcode.com/problems/sum-root-to-leaf-numbers/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Sum Root To Leaf Numbers")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int?[] Input) item)
    {
        var response = SumNumbers(item.Input.ToTreeNode());
        Assert.That(item.Output, Is.EqualTo(response));
    }

    public static IEnumerable<(int Output, int?[] Input)> Input =>
        new List<(int Output, int?[] Input)>()
        {
            (25, [1, 2, 3]),
        };
}
namespace LeetCode.MediumProblems;

public class KthSmallestElementInABst
{
    public int KthSmallest(TreeNode root, int k)
    {
        Stack<int> stack = new Stack<int>();
        DFS(root, k, stack);
        return stack.Pop();
    }

    private void DFS(TreeNode node, int k, Stack<int> stack)
    {
        if (node != null)
        {
            DFS(node.left, k, stack);
            if (stack.Count < k)
            {
                stack.Push(node.val);
                DFS(node.right, k, stack);
            }
        }
    }

    [Test(Description = "https://leetcode.com/problems/kth-smallest-element-in-a-bst/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Kth smallest element in a BST")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, (int?[], int) Input) item)
    {
        var response = KthSmallest(item.Input.Item1.ToTreeNode(), item.Input.Item2);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, (int?[], int) Input)> Input =>
        new List<(int, (int?[], int))>()
        {
            (3, ([5, 3, 6, 2, 4, null, null, 1], 3)), 
        };
}
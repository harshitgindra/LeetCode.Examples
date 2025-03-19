using Easy;
using LeetCode.SharedUtils;


namespace LeetCode.EasyProblems;

public class SameTree
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }

        if (q == null && p != null || q != null && p == null)
        {
            return false;
        }

        if (p.val != q.val)
        {
            return false;
        }

        if (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right))
        {
            return true;
        }

        return false;
    }

    [Test(Description = "https://leetcode.com/problems/same-tree")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Same Tree")]
    [TestCaseSource(nameof(Input))]
    public void Test1((bool Output, (int?[], int?[]) Input) item)
    {
        var response = IsSameTree(item.Input.Item1.ToTreeNode(), item.Input.Item2.ToTreeNode());
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(bool Output, (int?[], int?[]) Input)> Input =>
        new List<(bool Output, (int?[], int?[]) Input)>()
        {
            (true, ([1, 2, 3], [1, 2, 3])),
        };
}
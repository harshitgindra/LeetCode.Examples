using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems;

public class BinaryTreePostOrderTraversal
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        IList<int> results = new List<int>();
        Process(root, results);
        return results;
    }

    private void Process(TreeNode node, IList<int> results)
    {
        if (node != null)
        {
            Process(node.left, results);

            Process(node.right, results);
                
            results.Add(node.val);
        }
    }
}
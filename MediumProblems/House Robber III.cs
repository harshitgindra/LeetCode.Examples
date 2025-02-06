using LeetCode.SharedUtils;

namespace LeetCode.MediumProblems
{
    public class House_Robber_III
    {
        public int Rob(TreeNode root)
        {
            var (x2, x) = Traverse(root);
            return x;
        }

        private (int, int) Traverse(TreeNode node)
        {
            if (node == null) return (0, 0);
            var (p2, p) = Traverse(node.left);
            var (q2, q) = Traverse(node.right);
            var max = Math.Max(node.val + p2 + q2, p + q);
            return (p + q, max);
        }

        [Test(Description = "https://leetcode.com/problems/house-robber-iii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("House Robber 3")]
        public void Test1()
        {
            var response = Rob(new TreeNode(3, new TreeNode(2, null, new TreeNode(3)), new TreeNode(3, null, new TreeNode(1))));

            response = Rob(new TreeNode(3, new TreeNode(12, new TreeNode(1), new TreeNode(2))
            , new TreeNode(4, new TreeNode(2), new TreeNode(17))));
        }
    }
}

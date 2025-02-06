using LeetCode.SharedUtils;

namespace LeetCode.Hard
{
    public class Binary_Tree_Maximum_Path_Sum
    {
        int globalSum = int.MinValue;
        public int MaxPathSum(TreeNode root) {
            DFS(root);
            return globalSum;
        }

        private int DFS(TreeNode root) {
            if (root == null) return 0;

            var leftSum = DFS(root.left);
            var rightSum = DFS(root.right);

            var localSum = root.val;
            localSum += Math.Max(0, leftSum);
            localSum += Math.Max(0, rightSum);

            globalSum = Math.Max(localSum, globalSum);

            return Math.Max(root.val, Math.Max(root.val + leftSum, root.val + rightSum));
        }
    }
}
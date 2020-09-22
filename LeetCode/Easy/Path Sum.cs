namespace LeetCode.Easy
{
    class Path_Sum
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                return Add(root, sum, root.val);
            }
        }

        private bool Add(TreeNode node, int sum, int currSum)
        {
            if (node.left == null && node.right == null)
            {
                return sum == currSum;
            }
            else
            {
                if (node.left != null)
                {
                    currSum += node.left.val;
                    if (Add(node.left, sum, currSum))
                    {
                        return true;
                    }
                    currSum -= node.left.val;
                }

                if (node.right != null)
                {
                    currSum += node.right.val;
                    if (Add(node.right, sum, currSum))
                    {
                        return true;
                    }
                    currSum -= node.right.val;
                }
            }

            return false;
        }
    }
}

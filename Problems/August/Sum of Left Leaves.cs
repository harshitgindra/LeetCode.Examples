namespace LeetCode.August
{
    class Sum_of_Left_Leaves
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            return _SumLeftNode(root, 0, false);
        }

        private int _SumLeftNode(TreeNode root, int sum, bool isLeft = false)
        {
            if (root != null)
            {
                if (isLeft && root.left == null && root.right == null)
                {
                    sum += root.val;
                }
                else
                {
                    //***
                    //*** Check the left node of the root
                    //***
                    sum = _SumLeftNode(root.left, sum, true);
                    //***
                    //*** Check the right node of the root
                    //***
                    sum = _SumLeftNode(root.right, sum, false);
                }
            }

            return sum;
        }
    }
}

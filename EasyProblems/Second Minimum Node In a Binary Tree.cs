using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems
{
    class Second_Minimum_Node_In_a_Binary_Tree
    {
        public int FindSecondMinimumValue(TreeNode root)
        {
            HashSet<int> result = new HashSet<int>();
            Read(root, result);

            if (result.Count < 2)
            {
                return -1;
            }
            else
            {
                return result.OrderBy(x => x).ElementAt(1);
            }
        }

        private void Read(TreeNode node, HashSet<int> result)
        {
            if (node != null)
            {
                result.Add(node.val);
                Read(node.left, result);
                Read(node.right, result);
            }
        }
    }
}

using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems
{
    class Leaf_Similar_Trees
    {
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var val1 = new List<int>();
            var val2 = new List<int>();
            GetNodes(root1, val1);
            GetNodes(root2, val2);

            if(val1.Count != val2.Count)
            {
                return false;
            }

            for (int i = 0; i < val1.Count; i++)
            {
                if(val1[i] != val2[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void GetNodes(TreeNode node, List<int> val)
        {
            if (node != null)
            {
                if (node.left == null && node.right == null)
                {
                    val.Add(node.val);
                }
                else
                {
                    GetNodes(node.left, val);
                    GetNodes(node.right, val);
                }
            }
        }
    }
}

using LeetCode.SharedUtils;

namespace LeetCode.MediumProblems
{
    public class BSTIterator
    {
        readonly int[] arry;
        int lastIndex;

        public BSTIterator(TreeNode root)
        {
            var val = Read(root, new List<int>());
            arry = val.ToArray();
            Array.Sort(arry);
            lastIndex = -1;
        }

        private List<int> Read(TreeNode node, List<int> val)
        {
            if (node != null)
            {
                val.Add(node.val);
                val = Read(node.left, val);
                val = Read(node.right, val);
            }
            return val;
        }

        /** @return the next smallest number */
        public int Next()
        {
            for (int i = lastIndex + 1; i < arry.Length; i++)
            {
                lastIndex = i;
                return arry[i];
            }
            throw new Exception();
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return lastIndex < arry.Length - 1;
        }
    }
}

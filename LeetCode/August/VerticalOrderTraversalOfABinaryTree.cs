using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class VerticalOrderTraversalOfABinaryTree
    {
        private readonly IDictionary<int, IList<(int, int)>> _records = new Dictionary<int, IList<(int, int)>>();

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            if (root != null)
            {
                _records.Add(0, new List<(int, int)>() { (root.val, 0) });
                _ProcessChildNodes(root, 0, 0);

                IList<IList<int>> result = new List<IList<int>>();
                foreach (var item in _records.OrderBy(x => x.Key))
                {
                    result.Add(item.Value.OrderByDescending(x => x.Item2)
                        .ThenBy(x => x.Item1)
                        .Select(x => x.Item1)
                        .ToList());
                }

                return result;
            }

            return null;
        }

        private void _LogNode(TreeNode node, int x, int y)
        {
            if (node != default)
            {
                if (_records.ContainsKey(x))
                {
                    _records[x].Add((node.val, y));
                }
                else
                {
                    _records.Add(x, new List<(int, int)>() { (node.val, y) });
                }
            }
        }

        private void _ProcessChildNodes(TreeNode node, int x, int y)
        {
            if (node != default)
            {
                _LogNode(node?.right, x + 1, y - 1);
                _LogNode(node?.left, x - 1, y - 1);
                //***
                //*** Process left node
                //***
                _ProcessChildNodes(node?.left, x - 1, y - 1);

                //***
                //*** Process right node
                //***
                _ProcessChildNodes(node?.right, x + 1, y - 1);
            }
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return $"{this.val}";
        }
    }
}

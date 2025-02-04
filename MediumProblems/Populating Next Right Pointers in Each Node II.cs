using System.Collections.Generic;
using System.Linq;


namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/
    /// </summary>
    public class Populating_Next_Right_Pointers_in_Each_Node_II
    {
        public Node Connect(Node root)
        {
            Read(root);
            return root;
        }

        public void Read(Node node)
        {
            if (node != null)
            {
                if (node.left != null)
                {
                    node.left.next = node.right;
                }

                if (node.right != null && node.next != null)
                {
                    node.right.next = node.next.left;
                }

                Read(node.left);
                Read(node.right);
            }
        }
        
        
        private Dictionary<int, List<Node>> _dict;

        public Node Connect2(Node root)
        {
            _dict = new Dictionary<int, List<Node>>();
            Helper(root, 1);
            return root;
        }

        private void Helper(Node node, int level)
        {
            if (node != null)
            {
                if (_dict.ContainsKey(level))
                {
                    var curr = _dict[level].Last();
                    curr.next = node;
                    _dict[level].Add(node);
                }
                else
                {
                    _dict.Add(level, new List<Node>() {node});
                }

                Helper(node.left, level + 1);
                Helper(node.right, level + 1);
            }
        }


        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node()
            {
            }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
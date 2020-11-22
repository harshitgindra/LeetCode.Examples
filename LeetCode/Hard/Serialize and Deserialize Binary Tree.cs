using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Hard
{
    /// <summary>
    /// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
    /// </summary>
    class Serialize_and_Deserialize_Binary_Tree
    {
        public string serialize(TreeNode root)
        {

            if (root == null)
                return "";

            StringBuilder sb = new StringBuilder();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                TreeNode curr = queue.Dequeue();

                if (curr != null)
                {
                    sb.Append(curr.val + ",");
                    queue.Enqueue(curr.left);
                    queue.Enqueue(curr.right);
                }
                else
                    sb.Append("#,");
            }

            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {

            if (data == "")
                return null;

            string[] nodes = data.Split(',', StringSplitOptions.RemoveEmptyEntries);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(nodes[0]));
            queue.Enqueue(root);

            for (int i = 1; i < nodes.Length; i++)
            {
                TreeNode curr = queue.Dequeue();
                if (nodes[i] != "#")
                {
                    TreeNode left = new TreeNode(int.Parse(nodes[i]));
                    curr.left = left;
                    queue.Enqueue(left);
                }

                if (nodes[++i] != "#")
                {
                    TreeNode right = new TreeNode(int.Parse(nodes[i]));
                    curr.right = right;
                    queue.Enqueue(right);
                }
            }

            return root;
        }
    }
}

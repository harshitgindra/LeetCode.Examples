using LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.August
{
    /// <summary>
    /// https://leetcode.com/problems/count-good-nodes-in-binary-tree/
    /// </summary>
    class Count_Good_Nodes_in_Binary_Tree
    {
        private int _result;
        public int GoodNodes(TreeNode root)
        {
            this.Iterate(root, root == null ? 0 : root.val);
            return _result;
        }

        private void Iterate(TreeNode node, int max)
        {
            if (node != null)
            {
                //***
                //*** Node value is greater or equal to max
                //*** Increement result
                //***
                if (node.val >= max)
                {
                    _result++;
                    max = node.val;
                }

                //***
                //*** Run the iteration for left and right child nodes
                //***
                this.Iterate(node.left, max);
                this.Iterate(node.right, max);
            }
        }
    }
}

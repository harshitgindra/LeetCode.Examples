using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Maximum_Depth_of_Binary_Tree
    {
        //https://leetcode.com/problems/maximum-depth-of-binary-tree/submissions/
        public int MaxDepth(TreeNode root)
        {
            int max = Check(root, 0, 0);
            return max;
        }


        private int Check(TreeNode node, int level, int maxLevel)
        {
            if (node == null)
            {
                return Math.Max(level, maxLevel);
            }
            else
            {
                maxLevel = Check(node.left, level + 1, maxLevel);

                maxLevel = Check(node.right, level + 1, maxLevel);

                return maxLevel;
            }
        }
    }
}
